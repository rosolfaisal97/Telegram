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
    public class GroupMessageRepositoty : IGroupMessageRepositoty
    {
        private readonly IDbContext DbContext;

        public GroupMessageRepositoty(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CreateGroupMessage(GroupMessage groupMessage)
        {
            var p = new DynamicParameters();
            p.Add("@cfrom_id", groupMessage.from_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cgroup_id", groupMessage.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ccontent", groupMessage.content, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupMessage_Package.CreateGroupMessage", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteGroupMessage(int id)
        {
            var p = new DynamicParameters();
            p.Add("@cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupMessage_Package.DeleteGroupMessage", p, commandType: CommandType.StoredProcedure);
            return true; ;
        }

        public List<GroupMessage> GetAllGroupMessage()
        {
            IEnumerable<GroupMessage> result = DbContext.Connection.Query<GroupMessage>("GroupMessage_Package.GetAllGroupMessage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateGroupMessage(GroupMessage groupMessage)
        {
            var p = new DynamicParameters();
            p.Add("@cid", groupMessage.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cfrom_id", groupMessage.from_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cgroup_id", groupMessage.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ccontent", groupMessage.content, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupMessage_Package.UpdateGroupMessage", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
