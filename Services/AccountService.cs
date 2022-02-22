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

namespace LibApp.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto registerDto);
        string GenerateJWT(LoginUserDto loginDto);
    }

    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext context;
        private readonly IPasswordHasher<Customer> passwordHasher;
        private readonly AuthenticationSettings authenticationSettings;

        public AccountService(ApplicationDbContext context, IPasswordHasher<Customer> passwordHasher, AuthenticationSettings authentication)
        {
            this.context = context;
            this.passwordHasher = passwordHasher;
            this.authenticationSettings = authentication;
        }

        public void RegisterUser(RegisterUserDto registerDto)
        {
            var newCustomer = new Customer
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                RoleTypeId = registerDto.RoleTypeId
            };

            var hashedPassword = passwordHasher.HashPassword(newCustomer, registerDto.Password);
            newCustomer.PasswordHash = hashedPassword;

            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }

        public string GenerateJWT(LoginUserDto loginDto)
        {
            var customer = context.Customers
                .Include(u => u.RoleType)
                .FirstOrDefault(u => u.Email == loginDto.Email);

            if(customer == null)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var result = passwordHasher.VerifyHashedPassword(customer, customer.PasswordHash, loginDto.Password);

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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey));
            var credentiles = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                    authenticationSettings.JwtIssuer,
                    authenticationSettings.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: credentiles);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

    }
}
