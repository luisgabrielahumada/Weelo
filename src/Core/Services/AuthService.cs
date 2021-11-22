using Common.Infrastructure;
using System;
using Weelo.Dto.Auth;
using Weelo.Mapper.Interface;
using Weelo.Repository.Interface;
using Weelo.Services.Interface;

namespace Weelo.Services
{
    public class AuthService : IAuth
    {
        public IAuthRepository _db;
        public readonly Settings _settings;
        public readonly IAuthMapper _map;
        public AuthService(IAuthMapper map, IAuthRepository db)
        {
            _map = map;
            _db = db;
        }
        public TokenDto Login(UserDto req)
        {
            var user  = _map.MapearUser(req);
            // Access to the database.
            var resp = _db.LoginValidate(user);
           
            return resp;
        }
    }
}
