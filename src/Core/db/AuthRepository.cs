﻿using Common.Infrastructure;
using Common.Infrastructure.Helper;
using Core.Component.Library.SQL;
using System;
using System.Linq;
using Weelo.Domain.Auth;
using Weelo.Dto.Auth;
using Weelo.Repository.Interface;

namespace Weelo.Repository
{
    public class AuthRepository : IAuthRepository
    {
        readonly AppDatabase db;
        Settings _settings;
        public AuthRepository(Settings settings)
        {
            _settings = settings;
            db = new AppDatabase(settings.ConnectionStrings.ConnectionString);
        }
        public TokenDto LoginValidate(User req)
        {
            TokenDto resp = new TokenDto();
            var security = Encription.GetInstance(_settings.Configuration.Token);
            resp = new Execute(db, "DB_Login_Validate",
                              new
                              {
                                  login = req.Login,
                                  password = security.Encrypt(req.Password)
                              }).Procedure<TokenDto>()
                                .FirstOrDefault();
            resp.SessionId = Guid.NewGuid().ToString();
            resp.Token = new JwtSecurity.JwtSecurityWeb().GenerateJSONWebToken(resp, _settings);
            return resp;
        }
    }
}