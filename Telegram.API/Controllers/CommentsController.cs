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
   // [Authorize]
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
        public bool InsertComment([FromBody] CommentFormDTO comment)
        {
            return _commentsService.InsertComment(comment);
        }

        [HttpPost]
        public bool UpdateComment([FromBody] CommentFormDTO comment)
        {
            return _commentsService.UpdateComment(comment);
        }

        [HttpPost]
        public bool DeleteComment([FromBody] CommentFormDTO comment)
        {
            return _commentsService.DeleteComment(comment);
        }

        [HttpGet]
        [Route("{postId}")]
        public List<CommentDetailsDTO> GetPostComments(int postId)
        {
            return _commentsService.GetComments(postId);
        }


    }
}
