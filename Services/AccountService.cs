using LibApp.Data;
using LibApp.Dtos;
using LibApp.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto registerDto);
    }

    public class AccountService : IAccountService
    {
        public AccountService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterUserDto registerDto)
        {
            var newUser = new User
            {
                Email = registerDto.Email,
                RoleId = registerDto.RoleId
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, registerDto.Password);
            newUser.PasswordHash = hashedPassword;

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
    }
}
