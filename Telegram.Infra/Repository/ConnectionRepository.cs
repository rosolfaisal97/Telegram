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

namespace Telegram.Infra.Repository
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly IDbContext _dbContext;
        public ConnectionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool delete(Connection connection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@p_id", connection.Id, dbType: DbType.Int32);
            parameters.Add("@p_user_id", connection.UserId, dbType: DbType.Int32);
            parameters.Add("@p_connection_id", connection.ConnectionId, dbType: DbType.String);

            _dbContext.Connection
                .Execute("connection_package.delete_conn",
                         parameters,
                         commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ConnectionDTO> GetAll()
        {
            var result = _dbContext.Connection
                  .Query<ConnectionDTO>("connection_package.get_all",
                           commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public int GetAllCount()
        {
            var result = _dbContext.Connection
                .Query<int>("connection_package.get_all_count",
                         commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public ConnectionDTO GetItem(Connection connection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@p_id", connection.Id, dbType: DbType.Int32);
            parameters.Add("@p_user_id", connection.UserId, dbType: DbType.Int32);
            parameters.Add("@p_connection_id", connection.ConnectionId, dbType: DbType.String);

            var result = _dbContext.Connection
               .Query<ConnectionDTO>("connection_package.get_item", parameters,
                        commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool Insert(Connection connection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@p_user_id", connection.UserId, dbType: DbType.Int32);
            parameters.Add("@p_connection_id", connection.ConnectionId, dbType: DbType.String);

            var result = _dbContext.Connection
               .Execute("connection_package.insert_conn",parameters,
                        commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool update(Connection connection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@p_id", connection.Id, dbType: DbType.Int32);
            parameters.Add("@p_user_id", connection.UserId, dbType: DbType.Int32);
            parameters.Add("@p_connection_id", connection.ConnectionId, dbType: DbType.String);

            var result = _dbContext.Connection
               .Execute("connection_package.update_conn", parameters,
                        commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
