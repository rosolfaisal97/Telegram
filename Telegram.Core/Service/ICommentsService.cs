using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface ICommentsService
    {

        CommentDetailsDTO GetComment(int commentId);
        bool InsertComment(CommentFormDTO comment);
        bool UpdateComment(CommentFormDTO comment);
        bool DeleteComment(CommentFormDTO comment);
        List<CommentDetailsDTO> GetComments(int postId);
        List<Comments> GetAllComments();
        List<CommentJoinUser> GetAllCommentPost();
    }
}
