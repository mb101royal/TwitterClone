using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AuthDtos;
using TwitterClone.Business.Dtos.TokenDtos;

namespace TwitterClone.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginDto dto);
    }
}
