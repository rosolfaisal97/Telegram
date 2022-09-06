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

        public bool AcceptFriendRequest(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            parameters.Add("@userTo", user.UserToId, DbType.Int32);

            DbContext.Connection.
              ExecuteAsync("Friends_Package.AcceptFriendRequest",
                           parameters,
                           commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteFriendRequest(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            parameters.Add("@userTo", user.UserToId, DbType.Int32);

            DbContext.Connection.
                 ExecuteAsync("Friends_Package.DeleteFriendRequest",
                              parameters,
                              commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteFriendship(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            parameters.Add("@userTo", user.UserToId, DbType.Int32);

            DbContext.Connection.
              ExecuteAsync("Friends_Package.DeleteFriendship",
                           parameters,
                           commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool HasFriendship(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            parameters.Add("@userTo", user.UserToId, DbType.Int32);

            var result = DbContext.Connection.
                QueryAsync<int>("Friends_Package.HasFriendship",
                             parameters,
                             commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault() > 0;
        }

        public bool HeSent(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            parameters.Add("@userTo", user.UserFromId, DbType.Int32);

            var result = DbContext.Connection.
                     QueryAsync<int>("Friends_Package.HeSent",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault() > 0;

        }

        public bool InsertFriendRequest(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            parameters.Add("@userTo", user.UserToId, DbType.Int32);

             DbContext.Connection.
                ExecuteAsync("Friends_Package.InsertFriendRequest",
                             parameters,
                             commandType: CommandType.StoredProcedure);
            return true;
        }
        public FriendshipStatusDTO GetFriendship(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            parameters.Add("@userTo", user.UserToId, DbType.Int32);
            var result = DbContext.Connection.
                QueryAsync<FriendshipStatusDTO>("Friends_Package.GetFriendship",
                                                parameters,
                                                commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault();
        }

        public List<User> GetUserFriends(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            var result = DbContext.Connection.
                QueryAsync<User>("Friends_Package.GetUserFriends",
                                                parameters,
                                                commandType: CommandType.StoredProcedure);
            return result.Result.ToList();

        }

        public List<User> GetFriendshipRequests(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            var result = DbContext.Connection.
                QueryAsync<User>("Friends_Package.GetFriendshipRequests",
                                                parameters,
                                                commandType: CommandType.StoredProcedure);
            return result.Result.ToList();
        }

        public bool ReSentFriendRequest(UserFormDTO user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userFrom", user.UserFromId, DbType.Int32);
            parameters.Add("@userTo", user.UserToId, DbType.Int32);

            DbContext.Connection.
              ExecuteAsync("Friends_Package.ReSentFriendRequest",
                           parameters,
                           commandType: CommandType.StoredProcedure);
            return true;

        }
    }
}
