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
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly IDbContext DbContext;

        public GroupMemberRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CreateGroupMember(GroupMember groupMember)
        {
            var p = new DynamicParameters();
            p.Add("@cuser_id", groupMember.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cgroup_id", groupMember.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupMEMBER_Package.CreateGroupMEMBER", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteGroupMember(int id)
        {
            var p = new DynamicParameters();
            p.Add("@cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupMEMBER_Package.DeleteGroupMEMBER", p, commandType: CommandType.StoredProcedure);
            return true; ;
        }

        public List<GroupMember> GetAllGroupMember()
        {
            IEnumerable<GroupMember> result = DbContext.Connection.Query<GroupMember>("GroupMEMBER_Package.GetAllGroupMEMBER", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateGroupMember(GroupMember groupMember)
        {
            var p = new DynamicParameters();
            p.Add("@cid", groupMember.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cuser_id", groupMember.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cgroup_id", groupMember.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupMEMBER_Package.UpdateGroupMEMBER", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
