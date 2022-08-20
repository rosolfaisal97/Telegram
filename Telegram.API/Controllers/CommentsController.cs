using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        [Route("{commentId}")]
        public CommentDetailsDTO GetComment(int commentId)
        {
            return _commentsService.GetComment(commentId);
        }

        [HttpPost]
        [Route("{userId}/{postId}/{content}")]
        public bool InsertComment(int userId, int postId, string content)
        {
            return _commentsService.InsertComment(userId, postId, content);
        }

        [HttpPost]
        [Route("{id}/{content}")]
        public bool UpdateComment(int id, string content)
        {
            return _commentsService.UpdateComment(id, content);
        }

        [HttpPost]
        [Route("{id}")]
        public bool DeleteComment(int id)
        {
            return _commentsService.DeleteComment(id);
        }

        [HttpGet]
        [Route("{postId}")]
        public List<CommentDetailsDTO> GetPostComments(int postId)
        {
            return _commentsService.GetComments(postId);
        }


    }
}
