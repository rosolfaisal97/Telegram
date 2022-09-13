using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;
using Telegram.Infra.Repoisitory;

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


        [HttpPost]
        public bool DeleteUserBlock([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.DeleteUserBlock(userBlock);
        }

        [HttpPost]
        public UserBlockList InsertUserBlock([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.InsertUserBlock(userBlock);
        }

        [HttpPost]
        public List<My_block_ListDTO> GetUserBlockedList([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.My_block_List(userBlock);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public bool UpdateUserBlock([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.UpdateUserBlock(userBlock);
        }

        [HttpGet("infoBlock")]
        public List<GetAllBlockUserAndSendEmailDTO> GetAllBlockUserAndSendEmail()
        {
            return userBlockListService.GetAllBlockUserAndSendEmail();

        }
        [HttpGet("blocksendemail/{id}")]
        public bool EmailSend(int id)
        {
            return userBlockListService.EmailSend(id);
        }
    }
}
