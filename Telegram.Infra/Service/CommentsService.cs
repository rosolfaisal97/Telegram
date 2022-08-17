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

        public CommentDetailsDTO GetComment(int id)
        {
           return _commentsRepository.GetComment(id);
        }

        public List<CommentDetailsDTO> GetComments(int postId)
        {
            return _commentsRepository.GetComments(postId);
        }

        public bool InsertComment(int userId, int postId, string content)
        {
            return _commentsRepository.InsertComment(userId, postId, content);
        }

        public bool UpdateComment(int id, string content)
        {
           return _commentsRepository.UpdateComment(id, content);
        }
    }
}
