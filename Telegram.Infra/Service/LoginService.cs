using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    
    public class LoginService : ILoginService
    {
        private readonly ILogin authon;

        private readonly ILogin LoginRepo;

        public LoginService(ILogin LoginRepo, ILogin AuthLogin)
        {
            this.LoginRepo = LoginRepo;
            this.authon = AuthLogin;
        }

        public string Authentication_jwt(AuthLoginREPO login)
        {
            var result = authon.AuthLogin(login);

            if (result == null)
            {
                return null;
            }


            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, 1.ToString())

                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }

        //public AuthLoginREPO AuthLogin(AuthLoginREPO login)
        //{
        //    return LoginRepo.AuthLogin(login);
        //}

        public bool DeleteLogin(int L_id)
        {
            return LoginRepo.DeleteLogin(L_id);
        }

        public List<Login> GetAllLogin()
        {
            return LoginRepo.GetAllLogin();
        }

        public Login InsertLogin(Login logins)
        {
            return LoginRepo.InsertLogin(logins);
        }

        public bool RePasswordUser(RePasswordUserrEPO rep)
        {
            return LoginRepo.RePasswordUser(rep);
        }

        public bool UpdateLogin(Login logins)
        {
            return LoginRepo.UpdateLogin(logins);
        }
    }
}
