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
    public class PostMediaController : Controller
    {
        private readonly IPostMediaService PostMediaService;
        public PostMediaController(IPostMediaService PostMediaService)
        {
            this.PostMediaService = PostMediaService;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<MediaPost>), StatusCodes.Status200OK)]
        public List<MediaPost> GetAllPostMedia()
        {
            return PostMediaService.GetAllPostMedia();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(MediaPost), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePostMedia([FromBody] MediaPost PostMedia)
        {
            return PostMediaService.CreatePostMedia(PostMedia);
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<MediaPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePostMedia([FromBody] MediaPost PostMedia)
        {
            return PostMediaService.UpdatePostMedia(PostMedia);
        }

        [HttpDelete]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<MediaPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool DeleteChannel([FromBody] MediaPost media_Post)
        {
            return PostMediaService.DeletePostMedia(media_Post);
        }
    }
}
