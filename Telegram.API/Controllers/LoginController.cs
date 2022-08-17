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

        [HttpPost("auth")]
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

        [HttpDelete]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{L_id}")]
        public bool DeleteLogin(int L_id)
        {
            return LoginService.DeleteLogin(L_id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        public List<Login> GetAllLogin()
        {
            return LoginService.GetAllLogin();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Login), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Login InsertLogin([FromBody] Login logins)
        {
            return LoginService.InsertLogin(logins);
        }
        [HttpPost("password")]
        public bool RePasswordUser([FromBody]  RePasswordUserrEPO rep)
        {
            return LoginService.RePasswordUser(rep);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateLogin([FromBody] Login logins)
        {
            return LoginService.UpdateLogin(logins);
        }

    }
}
