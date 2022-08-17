using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelMemberController : Controller
    {
        private readonly IChannelMemberService ChannelMemberService;
        public ChannelMemberController(IChannelMemberService ChannelMemberService)
        {
            this.ChannelMemberService = ChannelMemberService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ChannelMember>), StatusCodes.Status200OK)]
        public List<ChannelMember> GetAllChannelMember()
        {
            return ChannelMemberService.GetAllChannelMember();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ChannelMember), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateChannelMember([FromBody] ChannelMember channelMember)
        {
            return ChannelMemberService.CreateChannelMember(channelMember);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<ChannelMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateChannelMember([FromBody] ChannelMember channelMember)
        {
            return ChannelMemberService.UpdateChannelMember(channelMember);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<ChannelMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteChannelMember(int id)
        {
            return ChannelMemberService.DeleteChannelMember(id);
        }
    }
}
