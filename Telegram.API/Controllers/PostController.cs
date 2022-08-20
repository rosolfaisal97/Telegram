using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : Controller
    {

        private readonly IPostService PostService;
        public PostController(IPostService PostService)
        {
            this.PostService = PostService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        public List<Post> GetAllPost()
        {
            return PostService.GetAllPost();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePost([FromBody] Post Post)
        {
            return PostService.CreatePost(Post);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePost([FromBody] Post Post)
        {
            return PostService.UpdatePost(Post);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeletePost(int id)
        {
            return PostService.DeletePost(id);
        }
    }
}
