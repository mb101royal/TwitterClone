using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Dtos.AuthDtos;
using TwitterClone.Business.Services.Interfaces;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserService _userService { get; }
        IAuthService _authService { get; }

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Post(LoginDto dto)
        {
            var login = await _authService.Login(dto);

            return Ok(login);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Post(RegisterDto dto)
        {
            await _userService.CreateAsync(dto);

            return Ok();
        }
    }
}
