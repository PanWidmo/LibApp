using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.SecurityTokenService;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto registerDto);
        string GenerateJWT(LoginUserDto loginDto);
    }

    public class AccountService : IAccountService
    {
        public AccountService(ApplicationDbContext context, IPasswordHasher<Customer> passwordHasher, AuthenticationSettings authentication)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authentication;
        }

        public void RegisterUser(RegisterUserDto registerDto)
        {
            var newCustomer = new Customer
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                RoleTypeId = registerDto.RoleTypeId
            };

            var hashedPassword = _passwordHasher.HashPassword(newCustomer, registerDto.Password);
            newCustomer.PasswordHash = hashedPassword;

            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
        }

        public string GenerateJWT(LoginUserDto loginDto)
        {
            var customer = _context.Customers
                .Include(u => u.RoleType)
                .FirstOrDefault(u => u.Email == loginDto.Email);

            if(customer == null)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(customer, customer.PasswordHash, loginDto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{customer.Name}"),
                new Claim(ClaimTypes.Role, $"{customer.RoleType.Name}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentiles = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                    _authenticationSettings.JwtIssuer,
                    _authenticationSettings.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: credentiles);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Customer> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
    }
}
