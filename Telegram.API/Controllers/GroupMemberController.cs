using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GroupMemberController : Controller
    {
        private readonly IGroupMemberService groupMemberService;
        public GroupMemberController(IGroupMemberService _groupMemberService)
        {
            groupMemberService = _groupMemberService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<GroupMember>), StatusCodes.Status200OK)]
        public List<GroupMember> GetAllGroupMember()
        {
            return groupMemberService.GetAllGroupMember();
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(GroupMember), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateGroupMember([FromBody] GroupMember groupMember)
        {
            return groupMemberService.CreateGroupMember(groupMember);
        }



        [HttpDelete("delete")]
        [Authorize(Roles = "User,Admin")]
        public bool DeleteGroupMember([FromBody] GroupMember groupMember)
        {
            return groupMemberService.DeleteGroupMember(groupMember);
        }



        [HttpPut]
        [Authorize(Roles = "User")]
        public bool UpdateGroupMember([FromBody] GroupMember groupMember)
        {
            return groupMemberService.UpdateGroupMember(groupMember);
        }
    }
}
