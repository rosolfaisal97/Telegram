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
        public bool InsertComment([FromBody] CommentFormDTO comment)
        {
            return _commentsService.InsertComment(comment);
        }

        [HttpPost]
        public bool UpdateComment([FromBody] CommentFormDTO comment)
        {
            return _commentsService.UpdateComment(comment);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteComment(int id)
        {
            return _commentsService.DeleteComment(id);
        }

        [HttpGet]
        [Route("{postId}")]
        public List<CommentDetailsDTO> GetPostComments( int postId)
        {
            return _commentsService.GetComments(postId);
        }


        [HttpGet]
        public List<Comments> GetAllComments()
        {
            return _commentsService.GetAllComments();
        }

        [HttpGet]
        public List<CommentJoinUser> GetAllCommentPost()
        {
            return _commentsService.GetAllCommentPost();
        }

    }
}
