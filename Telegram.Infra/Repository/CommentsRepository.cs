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

        public bool DeleteComment(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cid", id, DbType.Int32);

            _dbContext.Connection
                .ExecuteAsync("Comments_Package.DeleteComment",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }

        public CommentDetailsDTO GetComment(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cid", id, DbType.Int32);

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

        public bool InsertComment(int userId, int postId, string content)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cuserId", userId, DbType.Int32);
            parameters.Add("@cpostId", postId, DbType.Int32);
            parameters.Add("@ccontent", content, DbType.String);

            _dbContext.Connection
                .ExecuteAsync("Comments_Package.InsertComment",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateComment(int id, string content)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cid", id, DbType.Int32);
            parameters.Add("@ccontent", content, DbType.String);

            _dbContext.Connection
                .ExecuteAsync("Comments_Package.UpdateComment",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
