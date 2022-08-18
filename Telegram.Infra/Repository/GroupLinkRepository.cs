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
    public class GroupLinkRepository : IGroupLinkRepository
    {
        private readonly IDbContext DbContext;

        public GroupLinkRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CreateLinkGroup(GroupLink groupLink)
        {
            var p = new DynamicParameters();
            p.Add("@cLink", groupLink.link, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cperiod_time", groupLink.period_time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@cgroup_id", groupLink.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ccreated_at", groupLink.created_at, dbType: DbType.DateTime , direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupLink_Package.CreateGroupLink", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteLinkGroup(int id)
        {
            var p = new DynamicParameters();
            p.Add("@cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupLink_Package.DeleteGroupLink", p, commandType: CommandType.StoredProcedure);
            return true; ;
        }

        public List<GroupLink> GetAllLinkGroup()
        {
            IEnumerable<GroupLink> result = DbContext.Connection.Query<GroupLink>("GroupLink_Package.GetAllGroupLink", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateLinkGroup(GroupLink groupLink)
        {
            var p = new DynamicParameters();
            p.Add("@cid", groupLink.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cLink", groupLink.link, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cperiod_time", groupLink.period_time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@cgroup_id", groupLink.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ccreated_at", groupLink.created_at, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupLink_Package.UpdateGroupLink", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
