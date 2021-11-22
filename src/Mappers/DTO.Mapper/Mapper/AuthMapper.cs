using Weelo.Domain.Auth;
using Weelo.Dto.Auth;
using Weelo.Mapper.Interface;

namespace Weelo.Mapper
{
    public class AuthMapper : IAuthMapper
    {
        public TokenDto MapearTokenDto(User req)
        {
            var token = new TokenDto
            {
                Email = req.Email,
                Login = req.Login,
                Name = req.Name,
            };

            return token;
        }

        public User MapearUser(UserDto req)
        {
            var user = new User
            {
                Login = req.Login,
                Password = req.Password
            };
            return user;
        }
    }
}
