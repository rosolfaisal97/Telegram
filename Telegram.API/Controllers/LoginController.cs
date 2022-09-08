using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Telegram.API.Hubs;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;
using Telegram.Infra.Repoisitory;
using Telegram.Infra.Repository;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]


    //[Authorize] 
    public class LoginController : ControllerBase
    {

        private readonly ILoginService LoginService;

        public LoginController(ILoginService LoginService)
        {
            this.LoginService = LoginService;
        }


        //test
        [HttpGet]
        [Authorize(Roles = "User")]
        public AuthLoginDTO GetUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = LoginService.GetCurrentUser(identity);
            return user;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public AuthLoginDTO GetAdmin()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = LoginService.GetCurrentUser(identity);
            return user;
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public AuthLoginDTO GetUserAndAdmin()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = LoginService.GetCurrentUser(identity);
            user.Username = "YOU ARE ADMIN OR USER>>" + user.Username;
            return user;
        }

        [HttpGet]
        public AuthLoginDTO AllPublic()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = LoginService.GetCurrentUser(identity);
            user.Username = "Public For ALl>>";
            return user;
        }
        //end test




        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult authon([FromBody] AuthLoginDTO login)
        {
            var result = LoginService.AuthenticationJWT(login);

            if (result == null)
            {
                return Unauthorized(); //401
            }

            return Ok(result); //200
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool DeleteLogin([FromBody] Login login)
        {
            return LoginService.DeleteLogin(login);
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
        public Login InsertLogin([FromBody] Login login)
        {
            return LoginService.InsertLogin(login);
        }
        [HttpPost]
        public bool RePasswordUser([FromBody] RePasswordDTO rePasswordDTO)
        {
            return LoginService.RePasswordUser(rePasswordDTO);
        }

        [HttpPost("Chackpassword")]
        public bool ChackPassword([FromBody] RePasswordDTO rePasswordDTO)
        {
            return LoginService.ChackPassword(rePasswordDTO);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateLogin([FromBody] Login login)
        {
            return LoginService.UpdateLogin(login);
        }

    }
}
