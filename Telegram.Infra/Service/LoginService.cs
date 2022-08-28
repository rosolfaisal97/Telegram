using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        private readonly ILogin LoginRepo;
        private readonly IConfiguration _configuration;

        public LoginService(ILogin LoginRepo, IConfiguration configuration)
        {
            this.LoginRepo = LoginRepo;
            _configuration = configuration;
        }

        public AuthLoginDTO GetCurrentUser(ClaimsIdentity claims)
        {
            if (claims == null)
                return null;

            var userClaims = claims.Claims;
            return new AuthLoginDTO
            {
                Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                RoleName = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value,
                Email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
            };

        }



        public string AuthenticationJWT(AuthLoginDTO login)
        {
            var result = LoginRepo.AuthLogin(login);
            if (result == null) return null;

            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["jwt:Audience"],
                Audience = _configuration["jwt:Issuer"],

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userName", result.Username),
                    new Claim("loginId", result.LoginId.ToString()),
                    new Claim(ClaimTypes.Role, result.RoleName),
                    new Claim(ClaimTypes.Email, result.Email),
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(tokenKey,
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool DeleteLogin(Login login)
        {
            return LoginRepo.DeleteLogin(login);
        }

        public List<Login> GetAllLogin()
        {
            return LoginRepo.GetAllLogin();
        }

        public Login InsertLogin(Login login)
        {
            return LoginRepo.InsertLogin(login);
        }

        public bool RePasswordUser(RePasswordDTO rePasswordDTO)
        {
            return LoginRepo.RePasswordUser(rePasswordDTO);
        }
        public bool ChackPassword(RePasswordDTO rePasswordDTO)
        {
            return LoginRepo.ChackPassword(rePasswordDTO);
        }

            public bool UpdateLogin(Login login)
        {
            return LoginRepo.UpdateLogin(login);
        }


    }
}
