using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Infra.Common;

namespace Telegram.Infra.Repository
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly IDbContext _dbContext;
        public ReactionRepository(IDbContext _DbContext)
        {
            _dbContext = _DbContext;
        }


        public bool DeleteReaction(int userId, int postId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ruserId", userId, dbType: DbType.Int32);
            parameters.Add("@rpostId", postId, dbType: DbType.Int32);

            _dbContext.Connection.ExecuteAsync("Reaction_Package.DeleteReaction",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<ReactionDetailsDTO> GetPostReactions(int postId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@postId", postId, dbType: DbType.Int32);

            var result = _dbContext.Connection
                 .QueryAsync<ReactionDetailsDTO>("Reaction_Package.GetPostReactions",
                                                                  parameters,
                                                                  commandType: CommandType.StoredProcedure);

            return result.Result.ToList();
        }

        public bool InsertReaction(int userId, int postId, int isReact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ruserId", userId, dbType: DbType.Int32);
            parameters.Add("@rpostId", postId, dbType: DbType.Int32);
            parameters.Add("@isReact", isReact, dbType: DbType.Int32);

            _dbContext.Connection.ExecuteAsync("Reaction_Package.InsertReaction",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool IsAlreadyReacted(int userId, int postId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ruserId", userId, dbType: DbType.Int32);
            parameters.Add("@rpostId", postId, dbType: DbType.Int32);
 
           var result= _dbContext.Connection.QueryAsync<int>("Reaction_Package.IsAlreadyReacted",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return result.Result.FirstOrDefault() > 0;
        }

        public bool UpadteReaction(int userId, int postId, int isReact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ruserId", userId, dbType: DbType.Int32);
            parameters.Add("@rpostId", postId, dbType: DbType.Int32);
            parameters.Add("@isReact", isReact, dbType: DbType.Int32);

            _dbContext.Connection.ExecuteAsync("Reaction_Package.UpdateReaction",
                                               parameters,
                                               commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
