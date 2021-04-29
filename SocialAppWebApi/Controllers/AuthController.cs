using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.LoginAsync(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            return result.Success ? Ok(result.Data) : BadRequest(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userMailExists = await _authService.UserExistsAsync(userForRegisterDto.Email);
            if (!userMailExists.Success)
            {
                return BadRequest("Kullanıcı mevcut");
            }
            var registerResult = await _authService.RegisterAsync(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);

            return result.Success ? Ok(result.Data) : BadRequest("Sistemde bir hata oluştu");
        }

    }
}
