using Weelo.Dto.Auth;

namespace Weelo.Services.Interface
{
    public interface IAuth
    {
        TokenDto Login(UserDto req);
    }
}
