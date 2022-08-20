using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ReactionController : Controller
    {
        private readonly IReactionService _reactionService;
        public ReactionController(IReactionService reactionService)
        {
            _reactionService = reactionService;
        }

        [HttpPost]
        [Route("{userId}/{postId}/{isReact}")]
        public bool InsertReaction(int userId, int postId, int isReact)
        {
            return _reactionService.InsertReaction(userId, postId, isReact);

        }

        [HttpPost]
        [Route("{userId}/{postId}/{isReact}")]
        public bool UpadteReaction(int userId, int postId, int isReact)
        {
            return _reactionService.UpadteReaction(userId, postId, isReact);
        }

        [HttpPost]
        [Route("{userId}/{postId}")]
        public bool DeleteReaction(int userId, int postId)
        {
            return _reactionService.DeleteReaction(userId, postId);

        }

        [HttpGet]
        [Route("postId")]
        public List<ReactionDetailsDTO> GetPostReactions(int postId)
        {
            return _reactionService.GetPostReactions(postId);
        }

    }
}
