using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   // [Authorize]
    public class UsersController : Controller
    {
        private readonly IusersService usersService;
        public UsersController(IusersService usersService)
        {
            this.usersService = usersService;
        }


        [HttpDelete("delete")]
        public bool DeleteUsers(User user)
        {
            return usersService.DeleteUsers(user);
        }

        [HttpGet]
         public List<User> GetAllUsers()
        {
            return usersService.GetAllUsers();
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public User InsertUsers([FromBody] User user)
        {
            return usersService.InsertUsers(user);
        }

        [HttpPost("NumberOfUser")]
        public List<NumberOfUserdto> NumberOfUser()
        {
            return usersService.NumberOfUser();
        }

        [HttpPost("NumberUserByGender")]
        public List<NumberOfUserByGenderdto> NumberOfUserByGender([FromBody] User user)
        {
            return usersService.NumberOfUserByGender(user);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public InsertUsersRepo RegisterUser([FromBody] InsertUsersRepo InsertUser)
        {
            return usersService.RegisterUser(InsertUser);
        }

        [HttpPost]
        public List<SearchUserInfo> SarchUserInfo([FromBody]string search)
        {
            return usersService.SarchUserInfo(search);
        }

        [HttpPost("SearchDate/{dateto}/{datefrom}")]

        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(DateTime dateto, DateTime datefrom)
        {
            return usersService.SearchButweenTwoDate(dateto, datefrom);
        }

        [HttpPut("UpdateProfile")]
        public bool UpdateProfileUser([FromBody] UpdateProfileUserDTO UpdateUser)
        {

            return usersService.UpdateProfileUser(UpdateUser);
        }
        [HttpPut]
        public bool UpdateUsers([FromBody] User user)
        {
            return usersService.UpdateUsers(user);
        }

        [HttpPost]
        [Route("UploadImageUser")]
        public UpdateProfileUserDTO UploadImageUser()
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    fileContent = stream.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var attachmentFileName = $"{fileName}{Path.GetExtension(file.Name)}";
                var fullPath = Path.Combine("F:\\Telegram\\Telegram\\src\\assets\\img", attachmentFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                UpdateProfileUserDTO Item = new UpdateProfileUserDTO();
                Item.U_image_path = fileName;
                return Item;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
