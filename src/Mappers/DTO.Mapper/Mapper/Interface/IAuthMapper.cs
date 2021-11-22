

using Weelo.Domain.Auth;
using Weelo.Dto.Auth;

namespace Weelo.Mapper.Interface
{
    public interface IAuthMapper
    {
        User MapearUser(UserDto req);
        TokenDto MapearTokenDto(User req);
    }
}
