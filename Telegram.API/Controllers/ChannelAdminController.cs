using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelAdminController : Controller
    {
        private readonly IChannelAdminService ChannelAdminService;
        public ChannelAdminController(IChannelAdminService ChannelAdminService)
        {
            this.ChannelAdminService = ChannelAdminService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ChannelAdmin>), StatusCodes.Status200OK)]
        public List<ChannelAdmin> GetAllChannelAdmin()
        {
            return ChannelAdminService.GetAllChannelAdmin();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ChannelAdmin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateChannelAdmin([FromBody] ChannelAdmin channelAdmin )
        {
            return ChannelAdminService.CreateChannelAdmin(channelAdmin);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<ChannelAdmin>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateChannelAdmin([FromBody] ChannelAdmin channelAdmin )
        {
            return ChannelAdminService.UpdateChannelAdmin(channelAdmin);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<ChannelAdmin>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteChannelAdmin(int id)
        {
            return ChannelAdminService.DeleteChannelAdmin(id);
        }

    }
}
