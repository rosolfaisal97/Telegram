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
    public class userController : ControllerBase
    {
         
        private readonly IusersService usersService;
        public userController(IusersService usersService)
        {
            this.usersService = usersService;
        }


        [HttpDelete("delete/{U_id}")]
        public bool DeleteUsers(int? U_id)
        {
            return usersService.DeleteUsers(U_id);
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return usersService.GetAllUsers();
        }

        [HttpPost]
        public User InsertUsers([FromBody]User uss)
        {
            return usersService.InsertUsers(uss);
        }

        [HttpPost("NumberOfUser")]
        public List<NumberOfUserdto> NumberOfUser()
        {
            return usersService.NumberOfUser();
        }

        [HttpPost("NumberUserByGender")]
        public List<NumberOfUserByGenderdto> NumberOfUserByGender([FromBody] NumberOfUserByGenderdto numberusergender)
        {
            return usersService.NumberOfUserByGender(numberusergender);
        }

        [HttpPost("Register")]
        public InsertUsersRepo RegisterUser([FromBody]InsertUsersRepo Ins)
        {
            return usersService.RegisterUser(Ins);
        }

        [HttpPost("SarchUserInfo")]
        public List<SearchUserInfo> SarchUserInfo([FromBody] SearchUserInfo searchUser)
        {
            return usersService.SarchUserInfo(searchUser);
        }

        [HttpPost("SearchDate")]
        public List<SearchButweenTwoDatedto> SearchButweenTwoDate([FromBody] SearchButweenTwoDatedto c)
        {
            return usersService.SearchButweenTwoDate(c);
        }
        [HttpPut("UpdateProfile")]
        public bool UpdateProfileUser([FromBody] UpdateProfileUserDTO Upd)
        {
            return usersService.UpdateProfileUser(Upd);
        }
        [HttpPut]
        public bool UpdateUsers([FromBody] User uss)
        {
            return usersService.UpdateUsers(uss);
        }
    }
}
