using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMessageController : Controller
    {
        private readonly IGroupMessageService groupMessageService;
        public GroupMessageController(IGroupMessageService _groupMessageService)
        {
            groupMessageService = _groupMessageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GroupMessage>), StatusCodes.Status200OK)]
        public List<GroupMessage> GetAllGroupMessage()
        {
            return groupMessageService.GetAllGroupMessage();
        }


        [HttpPost]
        [ProducesResponseType(typeof(GroupMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreategroupMessage([FromBody] GroupMessage groupMessage)
        {
            return groupMessageService.CreateGroupMessage(groupMessage);
        }



        [HttpDelete("delete/{id}")]
        public bool DeletegroupMessage(int id)
        {
            return groupMessageService.DeleteGroupMessage(id);

        }

        [HttpPut]
        public bool UpdategroupMessage([FromBody] GroupMessage groupMessage)
        {
            return groupMessageService.UpdateGroupMessage(groupMessage);
        }
    }
}
