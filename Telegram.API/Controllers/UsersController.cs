using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Telegram.Infra.Repoisitory;

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


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAllUsersNotActive")]

        public List<UserNotActiveDto> GetAllUsersNotActive()
        {
            return usersService.GetAllUsersNotActive();
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAllUsersActive")]

        public List<UserActiveDto> GetAllUsersActive()
        {
            return usersService.GetAllUsersActive();
        }



        [HttpPost]
        public bool DeleteUsers([FromBody] User user)
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


        [HttpPost]

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("NumberOfUser")]
 
        public List<NumberOfUserdto> NumberOfUser()
        {
            return usersService.NumberOfUser();
        }


        [HttpPost]
            [HttpPost("NumberUserByGender")]

        public List<NumberOfUserByGenderdto> NumberOfUserByGender([FromBody] User user)
        {
            return usersService.NumberOfUserByGender(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public InsertUsersRepo RegisterUser([FromBody] InsertUsersRepo InsertUser)
        {
            return usersService.RegisterUser(InsertUser);
        }

        [HttpPost]
        public List<SearchUserInfo> SarchUserInfo([FromBody] string search)
        {
            return usersService.SarchUserInfo(search);
        }

        [HttpPost]

        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(DateTime dateto, DateTime datefrom)
        {
            return usersService.SearchButweenTwoDate(dateto, datefrom);
        }

        [HttpPut]
        public bool UpdateProfileUser([FromBody] UpdateProfileUserDTO UpdateUser)
        {

            return usersService.UpdateProfileUser(UpdateUser);
        }
        [HttpPost]
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
                var fullPath = Path.Combine(@"D:\My Files\Telegram Project\front-end-3\Telegram\src\assets\img", attachmentFileName);

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

        [AllowAnonymous]
        [HttpGet("GetUserById/{U_id}")]
        public GetUserByIdDto GetUserById(int U_id)
        {
            return usersService.GetUserById(U_id);
        }



        [HttpPost ("AdminBlock/{id}")]
        public  List<AdminBlockDto> AdminBlock(int id)
        {
            return usersService.AdminBlock(id);
        }

        [HttpGet("AdminBlockList")]
        public List<AdminBlockDto> GetAllUsersBlocked()
        {
            return usersService.GetAllUsersBlocked();
        }



        [HttpPost("CheckStatusBlock")]
        public List<User> CheckStatusBlock([FromBody] int id)
        {
            return usersService.CheckStatusBlock(id);
        }

        [HttpGet("blockuser/{id}")]
        public bool EmailSenduserblock(int id)
        {
            return usersService.EmailSenduserblock(id);
        }



        [HttpGet("blockstore/{id}")]
        public bool sendstoreEmail(int id)
        {
            return usersService.sendstoreEmail(id);
        }


        [HttpPost]
        [Route("filturUser")]
        public List<SearchUserDto> SearchUser( [FromBody] SearchUserDto filter)
        {
            return usersService.SearchUser(filter);
        }


    }
}
