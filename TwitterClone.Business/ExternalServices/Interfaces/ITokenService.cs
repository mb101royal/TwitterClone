using TwitterClone.Business.Dtos.TokenDtos;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateToken(TokenParamsDto dto);
    }
}
