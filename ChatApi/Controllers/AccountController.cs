using System.Threading.Tasks;
using AutoMapper;
using ChatApi.Dtos;
using ChatApi.Models;
using ChatApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpGet("existing")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AccountDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return Ok(new AccountDto
            {
                DisplayName = user.DisplayName, 
                Email = user.Email, 
                ProfileUrl = user.ProfileUrl,
                Token = _tokenService.GenerateToken(user)
            });
        }
        

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return BadRequest();
            }
            else
            {
                var user = new AppUser
                {
                    UserName = registerDto.DisplayName,
                    DisplayName = registerDto.DisplayName,
                    Email = registerDto.Email,
                    ProfileUrl = registerDto.ProfileUrl,
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (!result.Succeeded) return BadRequest();
                return Ok();
            }
        }
    }
}