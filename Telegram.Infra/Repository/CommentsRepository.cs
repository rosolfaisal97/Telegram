using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Dapper;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly IDbContext _dbContext;
        public CommentsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteComment(CommentFormDTO comment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cid", comment.CommentId, DbType.Int32);

            _dbContext.Connection
                .ExecuteAsync("Comments_Package.DeleteComment",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<CommentJoinUser> GetAllCommentPost()
        {
            IEnumerable<CommentJoinUser> result = _dbContext.Connection.Query<CommentJoinUser>("Comments_Package.GetAllPostComments", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Comments> GetAllComments()
        {
            IEnumerable<Comments> result = _dbContext.Connection.Query<Comments>("Comments_Package.GetAllComment", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public CommentDetailsDTO GetComment(int commentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cid", commentId, DbType.Int32);

           var result = _dbContext.Connection
                .QueryAsync<CommentDetailsDTO>("Comments_Package.GetComment",
                 parameters,
                 commandType: CommandType.StoredProcedure
                 );

            return result.Result.FirstOrDefault();
        }

        public List<CommentDetailsDTO> GetComments(int postId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@postId", postId, DbType.Int32);

            var result = _dbContext.Connection
                 .QueryAsync<CommentDetailsDTO>("Comments_Package.GetPostComments",
                  parameters,
                  commandType: CommandType.StoredProcedure
                  );

            return result.Result.ToList();
        }

        public bool InsertComment(CommentFormDTO comment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cuserId", comment.UserId, DbType.Int32);
            parameters.Add("@cpostId", comment.PostId, DbType.Int32);
            parameters.Add("@ccontent", comment.Content, DbType.String);

            _dbContext.Connection
                .ExecuteAsync("Comments_Package.InsertComment",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateComment(CommentFormDTO comment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cid", comment.CommentId, DbType.Int32);
            parameters.Add("@ccontent", comment.Content, DbType.String);

            _dbContext.Connection
                .ExecuteAsync("Comments_Package.UpdateComment",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
