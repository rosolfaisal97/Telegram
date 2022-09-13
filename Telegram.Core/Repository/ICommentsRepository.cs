using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface ICommentsRepository
    {

        CommentDetailsDTO GetComment(int  commentId);
        bool InsertComment(CommentFormDTO comment);
        bool UpdateComment(CommentFormDTO comment);
        bool DeleteComment(CommentFormDTO comment);
        List<CommentDetailsDTO> GetComments(int postId);
        List<CommentJoinUser> GetAllCommentPost();
        List<Comments> GetAllComments();
    }
}
