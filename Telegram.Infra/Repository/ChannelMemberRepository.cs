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
    public class ChannelMemberRepository: IChannelMemberRepository
    {
        private readonly IDbContext DbContext;
        public ChannelMemberRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool CreateChannelMember(ChannelMember channel_Member)
        {
            var p = new DynamicParameters();
            p.Add("@U_id", channel_Member.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_id", channel_Member.channel_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Channel_Member_Package.InsertChannelMember", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteChannelMember(int id)
        {
            var p = new DynamicParameters();
            p.Add("@CM_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Channel_Member_Package.DeleteChannelMember", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ChannelMember> GetAllChannelMember()
        {
            IEnumerable<ChannelMember> result = DbContext.Connection.Query<ChannelMember>("Channel_Member_Package.GetAllChannelMember", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateChannelMember(ChannelMember channel_Member)
        {
            var p = new DynamicParameters();
            p.Add("@CM_id", channel_Member.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@U_id", channel_Member.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_id", channel_Member.channel_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Channel_Member_Package.UpdateChannelMember", p, commandType: CommandType.StoredProcedure);
            return true;
        }



    }
}
