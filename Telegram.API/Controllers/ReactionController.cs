using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ReactionController : Controller
    {
        private readonly IReactionService _reactionService;
        public ReactionController(IReactionService reactionService)
        {
            _reactionService = reactionService;
        }



        [HttpPost]
        [ProducesResponseType(typeof(Reaction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool InsertReaction([FromBody] Reaction reaction)
        {
            return _reactionService.InsertReaction(reaction);

        }
        [HttpGet]
        [ProducesResponseType(typeof(Reaction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Reaction> getAllReaction()
        {
            return _reactionService.getAllReaction();
        }

        //[HttpPost]
        //[Route("{userId}/{postId}/{isReact}")]
        //public bool InsertReaction(int userId, int postId, int isReact)
        //{
        //    return _reactionService.InsertReaction(userId, postId, isReact);

        //}

        [HttpPost]
        [Route("{userId}/{postId}/{isReact}")]
        public bool UpadteReaction(int userId, int postId, int isReact)
        {
            return _reactionService.UpadteReaction(userId, postId, isReact);
        }

        [HttpDelete]
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

        [HttpPost]
        [Route("{userId}/{postId}")]
        public bool IsAlreadyReacted( int userId, int postId)
        {
            return _reactionService.IsAlreadyReacted(userId, postId);
        }
        [HttpGet]
        public List<AllReactionDto> AllReaction()
        {
            return _reactionService.AllReaction();
        }

    }
}
