using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.TokenDtos;
using TwitterClone.Business.ExternalServices.Interfaces;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.ExternalServices.Implements
{
    public class TokenService : ITokenService
    {
        IConfiguration _config { get; }

        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public TokenDto CreateToken(TokenParamsDto dto)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, dto.User.Id),
                new Claim(ClaimTypes.GivenName, dto.User.Fullname),
                new Claim(ClaimTypes.Name, dto.User.UserName),
                new Claim(ClaimTypes.Role, dto.Role)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256Signature);

            DateTime active = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["Jwt:ExpireMinutes"]));

            JwtSecurityToken jwt = new
                (
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    active,
                    expires,
                    credentials
                );

            JwtSecurityTokenHandler jwthandler = new();
            var token = jwthandler.WriteToken(jwt);

            TokenDto tokenInfoToShow = new()
            {
                Token = token,
                Expires = expires
            };

            return tokenInfoToShow;
        }
    }
}
