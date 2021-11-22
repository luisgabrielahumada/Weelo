using Common.Infrastructure;
using Weelo.Domain.Auth;
using Weelo.Dto.Auth;

namespace Weelo.Repository.Interface
{
    public interface IAuthRepository
    {
        TokenDto LoginValidate(User req);
    }
}
