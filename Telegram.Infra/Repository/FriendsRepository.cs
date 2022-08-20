using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using System.Linq;

namespace Telegram.Infra.Repository
{
    public class FriendsRepository : IFriendsRepository
    {
        private readonly IDbContext DbContext;
        public FriendsRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public bool AcceptFriendRequest(int userFrom, int userTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            parameters.Add("@userTo", userTo, DbType.Int32);

            DbContext.Connection.
              ExecuteAsync("Friends_Package.AcceptFriendRequest",
                           parameters,
                           commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteFriendRequest(int userFrom, int userTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            parameters.Add("@userTo", userTo, DbType.Int32);

            DbContext.Connection.
                 ExecuteAsync("Friends_Package.DeleteFriendRequest",
                              parameters,
                              commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteFriendship(int userFrom, int userTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            parameters.Add("@userTo", userTo, DbType.Int32);

            DbContext.Connection.
              ExecuteAsync("Friends_Package.DeleteFriendship",
                           parameters,
                           commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool HasFriendship(int userFrom, int userTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            parameters.Add("@userTo", userTo, DbType.Int32);

            var result = DbContext.Connection.
                QueryAsync<int>("Friends_Package.HasFriendship",
                             parameters,
                             commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault() > 0;
        }

        public bool HeSent(int userFrom, int userTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            parameters.Add("@userTo", userTo, DbType.Int32);

            var result = DbContext.Connection.
                     QueryAsync<int>("Friends_Package.HeSent",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault() > 0;

        }

        public bool InsertFriendRequest(int userFrom, int userTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            parameters.Add("@userTo", userTo, DbType.Int32);

             DbContext.Connection.
                ExecuteAsync("Friends_Package.InsertFriendRequest",
                             parameters,
                             commandType: CommandType.StoredProcedure);
            return true;
        }
        public FriendshipStatusDTO GetFriendship(int userFrom, int userTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            parameters.Add("@userTo", userTo, DbType.Int32);
            var result = DbContext.Connection.
                QueryAsync<FriendshipStatusDTO>("Friends_Package.GetFriendship",
                                                parameters,
                                                commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault();
        }

        public List<User> GetUserFriends(int userFrom)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            var result = DbContext.Connection.
                QueryAsync<User>("Friends_Package.GetUserFriends",
                                                parameters,
                                                commandType: CommandType.StoredProcedure);
            return result.Result.ToList();

        }

        public List<User> GetFriendshipRequests(int userFrom)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            var result = DbContext.Connection.
                QueryAsync<User>("Friends_Package.GetFriendshipRequests",
                                                parameters,
                                                commandType: CommandType.StoredProcedure);
            return result.Result.ToList();
        }

        public bool ReSentFriendRequest(int userFrom, int userTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", userFrom, DbType.Int32);
            parameters.Add("@userTo", userTo, DbType.Int32);

            DbContext.Connection.
              ExecuteAsync("Friends_Package.ReSentFriendRequest",
                           parameters,
                           commandType: CommandType.StoredProcedure);
            return true;

        }
    }
}
