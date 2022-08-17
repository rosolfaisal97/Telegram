using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
   
    public interface IReactionRepository
    {
        bool InsertReaction(int userId, int postId, int isReact);
        bool UpadteReaction(int userId, int postId, int isReact);
        bool DeleteReaction(int userId, int postId);
        List<ReactionDetailsDTO> GetPostReactions(int postId);

        bool IsAlreadyReacted (int userId, int postId);


    }
}
