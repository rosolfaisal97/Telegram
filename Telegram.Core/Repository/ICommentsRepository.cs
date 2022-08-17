using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface ICommentsRepository
    {

        CommentDetailsDTO GetComment(int id);
        bool InsertComment(int userId, int postId, string content);
        bool UpdateComment(int id, string content);
        bool DeleteComment(int id);
        List<CommentDetailsDTO> GetComments(int postId);
    }
}
