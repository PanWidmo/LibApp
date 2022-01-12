using LibApp.Data;
using LibApp.Dtos;
using LibApp.Entities;
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
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void RegisterUser(RegisterUserDto registerDto)
        {
            var user = new User
            {
                Email = registerDto.Email,
                RoleId = registerDto.RoleId
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private readonly ApplicationDbContext _context;
    }
}
