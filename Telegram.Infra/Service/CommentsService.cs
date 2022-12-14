using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public bool DeleteComment(int id)
        {
            return _commentsRepository.DeleteComment(id);
        }

        public List<CommentJoinUser> GetAllCommentPost()
        {
            return _commentsRepository.GetAllCommentPost();
        }

        public List<Comments> GetAllComments()
        {
            return _commentsRepository.GetAllComments();
        }

        public CommentDetailsDTO GetComment(int commentId)
        {
            return _commentsRepository.GetComment(commentId);
        }

        public List<CommentDetailsDTO> GetComments(int postId)
        {
            return _commentsRepository.GetComments(postId);
        }

        public bool InsertComment(CommentFormDTO comment)
        {
            return _commentsRepository.InsertComment(comment);
        }

        public bool UpdateComment(CommentFormDTO comment)
        {
            return _commentsRepository.UpdateComment(comment);
        }
    }
}
