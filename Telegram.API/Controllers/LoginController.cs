using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
         
        private readonly ILoginService LoginService;
        public LoginController(ILoginService LoginService)
        {
            this.LoginService = LoginService;
        }

        //[HttpGet("Autho")]
        //public AuthLoginREPO AuthLogin([FromBody] AuthLoginREPO login)
        //{
        //    return LoginService.AuthLogin(login);
        //}

        [HttpPost]
        public IActionResult authon([FromBody] AuthLoginREPO login)
        {
            var RESULT = LoginService.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                return Ok(RESULT); //200
            }


        }

        [HttpDelete("delete/{L_id}")]
        public bool DeleteLogin(int? L_id)
        {
            return LoginService.DeleteLogin(L_id);
        }

        [HttpGet]
        public List<Login> GetAllLogin()
        {
            return LoginService.GetAllLogin();
        }

        [HttpPost]
        public Login InsertLogin([FromBody] Login logins)
        {
            return LoginService.InsertLogin(logins);
        }
        [HttpPost("password")]
        public RePasswordUserrEPO RePasswordUser([FromBody] RePasswordUserrEPO rep)
        {
            return LoginService.RePasswordUser(rep);
        }

        [HttpPut]
        public bool UpdateLogin([FromBody] Login logins)
        {
            return LoginService.UpdateLogin(logins);
        }

    }
}
