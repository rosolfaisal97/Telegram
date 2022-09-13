using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class ReactionService : IReactionService 
    {

        private readonly IReactionRepository _reactionRepository;
        public ReactionService(IReactionRepository reactionRepository)
        {
            _reactionRepository = reactionRepository;
        }

        public List<AllReactionDto> AllReaction()
        {
            return _reactionRepository.AllReaction();
        }

        public bool DeleteReaction(int userId, int postId)
        {
            return _reactionRepository.DeleteReaction(userId, postId);
        }

        public List<Reaction> getAllReaction()
        {
            return _reactionRepository.getAllReaction();
        }

        public List<ReactionDetailsDTO> GetPostReactions(int postId)
        {
            var list = _reactionRepository.GetPostReactions(postId);
            return list;

        }

        public bool InsertReaction(Reaction reaction)
        {
            return _reactionRepository.InsertReaction(reaction);
        }

        //public bool InsertReaction(int userId, int postId, int isReact)
        //{
        //    if(IsAlreadyReacted(userId,postId))
        //       return UpadteReaction(userId,postId,1);

        //    return _reactionRepository.InsertReaction(userId, postId, isReact);


        //}

        public bool IsAlreadyReacted(int userId, int postId)
        {
            return _reactionRepository.IsAlreadyReacted(userId, postId);
        }

        public bool UpadteReaction(int userId, int postId, int isReact)
        {
            if (IsAlreadyReacted(userId, postId))
                return UpadteReaction(userId, postId, isReact);

            return false;
        }
    }
}
