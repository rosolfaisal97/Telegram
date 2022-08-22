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
    public class ChannelAdminRepository: IChannelAdminRepository
    {
        private readonly IDbContext DbContext;
        public ChannelAdminRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool CreateChannelAdmin(ChannelAdmin channel_Admin)
        {
            var p = new DynamicParameters();
            p.Add("@U_id", channel_Admin.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_id", channel_Admin.channel_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Channel_Admin_Package.InsertChannelAdmin", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteChannelAdmin(ChannelAdmin channel_Admin)
        {
            var p = new DynamicParameters();
            p.Add("@CA_id",channel_Admin.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Channel_Admin_Package.DeleteChannelAdmin", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ChannelAdmin> GetAllChannelAdmin()
        {

            IEnumerable<ChannelAdmin> result = DbContext.Connection.Query<ChannelAdmin>("Channel_Admin_Package.GetAllChannelAdmin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateChannelAdmin(ChannelAdmin channel_Admin)
        {
            var p = new DynamicParameters();
            p.Add("@CA_id", channel_Admin.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@U_id", channel_Admin.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_id", channel_Admin.channel_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Channel_Admin_Package.UpdateChannelAdmin", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
