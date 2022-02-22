using LibApp.Dtos;
using LibApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegisterUserDto registerDto)
        {
            accountService.RegisterUser(registerDto);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto loginDto)
        {
            string token = accountService.GenerateJWT(loginDto);
            return Ok(token);
        }

    }
}
