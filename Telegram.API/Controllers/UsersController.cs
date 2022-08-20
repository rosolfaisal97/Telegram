using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;
using Microsoft.AspNetCore.Authorization;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IusersService usersService;
        public UsersController(IusersService usersService)
        {
            this.usersService = usersService;
        }


        [HttpDelete("delete/{U_id}")]
        public bool DeleteUsers(int U_id)
        {
            return usersService.DeleteUsers(U_id);
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return usersService.GetAllUsers();
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public User InsertUsers([FromBody] User uss)
        {
            return usersService.InsertUsers(uss);
        }

        [HttpPost("NumberOfUser")]
        public List<NumberOfUserdto> NumberOfUser()
        {
            return usersService.NumberOfUser();
        }

        [HttpPost("NumberUserByGender/{U_gender}")]
        public List<NumberOfUserByGenderdto> NumberOfUserByGender(string U_gender)
        {
            return usersService.NumberOfUserByGender(U_gender);
        }

        [HttpPost("Register")]
        public InsertUsersRepo RegisterUser([FromBody] InsertUsersRepo Ins)
        {
            return usersService.RegisterUser(Ins);
        }

        [HttpPost("SarchUserInfo/{sarch}")]
        public List<SearchUserInfo> SarchUserInfo(string sarch)
        {
            return usersService.SarchUserInfo(sarch);
        }

        [HttpPost("SearchDate/{dateto}/{datefrom}")]

        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(DateTime dateto, DateTime datefrom)
        {
            return usersService.SearchButweenTwoDate(dateto, datefrom);
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
