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
    public class ChannelController : Controller
    {
        private readonly IChannelService ChannelService;
        public ChannelController(IChannelService ChannelService)
        {
            this.ChannelService = ChannelService;
        }


        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        public List<Channel> GetAllChannel()
        {
            return ChannelService.GetAllChannel();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Channel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateChannel([FromBody] Channel Channel)
        {
            return ChannelService.CreateChannel(Channel);
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateChannel([FromBody] Channel Channel)
        {
            return ChannelService.UpdateChannel(Channel);
        }

        [HttpDelete]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool DeleteChannel([FromBody] Channel channel)
        {
            return ChannelService.DeleteChannel(channel);
        }

    }
}
