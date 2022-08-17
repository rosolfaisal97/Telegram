using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostMediaController : Controller
    {
        private readonly IPostMediaService PostMediaService;
        public PostMediaController(IPostMediaService PostMediaService)
        {
            this.PostMediaService = PostMediaService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<MediaPost>), StatusCodes.Status200OK)]
        public List<MediaPost> GetAllPostMedia()
        {
            return PostMediaService.GetAllPostMedia();
        }

        [HttpPost]
        [ProducesResponseType(typeof(MediaPost), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePostMedia([FromBody] MediaPost PostMedia)
        {
            return PostMediaService.CreatePostMedia(PostMedia);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<MediaPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePostMedia([FromBody] MediaPost PostMedia)
        {
            return PostMediaService.UpdatePostMedia(PostMedia);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<MediaPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteChannel(int id)
        {
            return PostMediaService.DeletePostMedia(id);
        }
    }
}
