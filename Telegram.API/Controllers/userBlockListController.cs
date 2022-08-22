using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class userBlockListController : ControllerBase
    {
         
        private readonly IuserBlockListService userBlockListService;
        public userBlockListController(IuserBlockListService userBlockListService)
        {
            this.userBlockListService = userBlockListService;
        }


        [HttpDelete("delete")]
        [Authorize(Roles = "User")]
        public bool DeleteUserBlock([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.DeleteUserBlock(userBlock);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<UserBlockList> GetAllUserBlock()
        {
            return userBlockListService.GetAllUserBlock();
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public UserBlockList InsertUserBlock([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.InsertUserBlock(userBlock);
        }

        [HttpPost("MY_block")]
        [Authorize(Roles = "User,Admin")]
        public List<My_block_ListDTO> My_block_List([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.My_block_List(userBlock);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public bool UpdateUserBlock([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.UpdateUserBlock(userBlock);
        }
    }
}
