using TwitterClone.Business.Dtos.AuthDtos;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser user);
    }
}
