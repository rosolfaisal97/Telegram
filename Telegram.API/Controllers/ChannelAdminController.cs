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
    public class ChannelAdminController : Controller
    {
        private readonly IChannelAdminService ChannelAdminService;
        public ChannelAdminController(IChannelAdminService ChannelAdminService)
        {
            this.ChannelAdminService = ChannelAdminService;
        }


        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<ChannelAdmin>), StatusCodes.Status200OK)]
        public List<ChannelAdmin> GetAllChannelAdmin()
        {
            return ChannelAdminService.GetAllChannelAdmin();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(ChannelAdmin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateChannelAdmin([FromBody] ChannelAdmin channelAdmin )
        {
            return ChannelAdminService.CreateChannelAdmin(channelAdmin);
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<ChannelAdmin>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateChannelAdmin([FromBody] ChannelAdmin channelAdmin )
        {
            return ChannelAdminService.UpdateChannelAdmin(channelAdmin);
        }

        [HttpDelete]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeleteChannelAdmin([FromBody] ChannelAdmin channel_Admin)
        {
            return ChannelAdminService.DeleteChannelAdmin(channel_Admin);
        }

    }
}
