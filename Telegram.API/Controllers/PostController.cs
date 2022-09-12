using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;
using Telegram.Infra.Repository;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
     //[Authorize]
 
    public class PostController : Controller
    {

        private readonly IPostService PostService;
        public PostController(IPostService PostService)
        {
            this.PostService = PostService;
        }

        [HttpGet]
        [Route("chanel/{ch_id}")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        public List<Post> GetAllPostByChanel(int ch_id)
        {
            return PostService.GetAllPostByChanel(ch_id);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        public List<Post> GetAllPost()
        {
            return PostService.GetAllPost();
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<PostJoinDto>), StatusCodes.Status200OK)]
        public List<PostJoinDto> AllPost()
        {
            return PostService.AllPost();
        }



        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePost([FromBody] Post Post)
        {
            return PostService.CreatePost(Post);
        }

        [HttpPut]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePost([FromBody] Post Post)
        {
            return PostService.UpdatePost(Post);
        }

        [HttpDelete]
        //[Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeletePost(int id)
        {
            return PostService.DeletePost(id);
        }
    }
}
