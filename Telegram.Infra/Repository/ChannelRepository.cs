using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repository
{
    public class ChannelRepository: IChannelRepository
    {
        private readonly IDbContext DbContext;
        public ChannelRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool CreateChannel(Channel channel)
        {
            var p = new DynamicParameters();
            p.Add("@C_username", channel.username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@C_owner_id", channel.owner_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_bio", channel.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@C_is_private", channel.is_private, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_img", channel.Image_path, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Channel_Package.InsertChannel", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteChannel(int id)
        {
            var p = new DynamicParameters();
            p.Add("@C_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Channel_Package.DeleteChannel", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Channel> GetAllChannel()
        {
            IEnumerable<Channel> result = DbContext.Connection.Query<Channel>("Channel_Package.GetAllChannel", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateChannel(Channel channel)
        {
            var p = new DynamicParameters();
            p.Add("@(C_id", channel.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_username", channel.username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@C_owner_id", channel.owner_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_bio", channel.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@C_is_private", channel.is_private, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_img", channel.Image_path, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Channel_Package.UpdateChannel", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
