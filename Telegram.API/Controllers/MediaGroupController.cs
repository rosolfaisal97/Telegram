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
    public class MediaGroupController : Controller
    {


        private readonly IMediaGroupService mediaGroupService;
        public MediaGroupController(IMediaGroupService _mediaGroupService)
        {
            mediaGroupService = _mediaGroupService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<MediaGroup>), StatusCodes.Status200OK)]
        public List<MediaGroup> GetAllMediaGroup()
        {
            return mediaGroupService.GetAllMediaGroup();
        }


        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(MediaGroup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool createMediaGroup([FromBody] MediaGroup mediaGroup)
        {
            return mediaGroupService.CreateMediaGroup(mediaGroup);
        }



        [HttpDelete("delete")]
        [Authorize(Roles = "User,Admin")]
        public bool DeleteMediaGroup([FromBody] MediaGroup mediaGroup)
        {
            return mediaGroupService.DeleteMediaGroup(mediaGroup);
        }



        [HttpPut]
        [Authorize]
        public bool UpdateMediaGroup([FromBody] MediaGroup mediaGroup)
        {
            return mediaGroupService.UpdateMediaGroup(mediaGroup);
        }
    }
}
