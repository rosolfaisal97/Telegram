using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ChannelMemberController : Controller
    {
        private readonly IChannelMemberService ChannelMemberService;
        public ChannelMemberController(IChannelMemberService ChannelMemberService)
        {
            this.ChannelMemberService = ChannelMemberService;
        }


        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<ChannelMember>), StatusCodes.Status200OK)]
        public List<ChannelMember> GetAllChannelMember()
        {
            return ChannelMemberService.GetAllChannelMember();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(ChannelMember), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateChannelMember([FromBody] ChannelMember channelMember)
        {
            return ChannelMemberService.CreateChannelMember(channelMember);
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<ChannelMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateChannelMember([FromBody] ChannelMember channelMember)
        {
            return ChannelMemberService.UpdateChannelMember(channelMember);
        }

        [HttpDelete]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<ChannelMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool DeleteChannelMember([FromBody] ChannelMember channel_Member)
        {
            return ChannelMemberService.DeleteChannelMember(channel_Member);
        }
    }
}
