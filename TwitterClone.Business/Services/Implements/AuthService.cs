using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterClone.Business.Dtos.AuthDtos;
using TwitterClone.Business.Exceptions.Auth;
using TwitterClone.Business.ExternalServices.Interfaces;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _userManager { get; }
        ITokenService _tokenService { get; }

        public AuthService(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> Login(LoginDto dto)
        {
            AppUser? user;

            if (dto.UsernameOrEmail.Contains('@')) user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
            else user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);
            // Another option(1 line):
            /*await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == dto.UsernameOrEmail || u.Email == dto.UsernameOrEmail);*/

            if (user == null) throw new IncorrectUsernameOrPasswordException();

            var result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result) throw new IncorrectUsernameOrPasswordException();

            return _tokenService.CreateToken(user);
        }
    }
}
