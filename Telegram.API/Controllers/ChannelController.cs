using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService ChannelService;
        public ChannelController(IChannelService ChannelService)
        {
            this.ChannelService = ChannelService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        public List<Channel> GetAllChannel()
        {
            return ChannelService.GetAllChannel();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Channel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateChannel([FromBody] Channel Channel)
        {
            return ChannelService.CreateChannel(Channel);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateChannel([FromBody] Channel Channel)
        {
            return ChannelService.UpdateChannel(Channel);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteChannel(int id)
        {
            return ChannelService.DeleteChannel(id);
        }

    }
}
