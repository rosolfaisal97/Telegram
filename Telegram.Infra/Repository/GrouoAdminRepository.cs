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
    public class GrouoAdminRepository : IGrouoAdminRepository
    {
        private readonly IDbContext DbContext;

        public GrouoAdminRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public bool CreateAdminGroup(GroupAdmin groupAdmin)
        {
            var p = new DynamicParameters();
            p.Add("@cuser_ID", groupAdmin.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cGroup_ID", groupAdmin.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupAdmin_Package.CreateGroupAdmin", p, commandType: CommandType.StoredProcedure);
            return true;

        }

        public bool DeleteAdminGroup(GroupAdmin groupAdmin)
        {
            var p = new DynamicParameters();
            p.Add("@cid", groupAdmin.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupAdmin_Package.DeleteGroupAdmin", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<GroupAdmin> GetAllAdminGroup()
        {
            IEnumerable<GroupAdmin> result = DbContext.Connection.Query<GroupAdmin>("GroupAdmin_Package.GetAllGroupAdmin",commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool UpdateAdminGroup(GroupAdmin groupAdmin)
        {
            var p = new DynamicParameters();
            p.Add("@cid", groupAdmin.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cuser_ID", groupAdmin.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cGroup_ID", groupAdmin.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupAdmin_Package.UpdateGroupAdmin", p, commandType: CommandType.StoredProcedure);
            return true;

        }
    }
}
