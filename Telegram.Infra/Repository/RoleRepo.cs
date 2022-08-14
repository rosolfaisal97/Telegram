
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repoisitory
{
    public class RoleRepo : IRole
    {
        private readonly IDbContext DbContext;

        public RoleRepo(IDbContext _DbContext)
        {
            this.DbContext = _DbContext;
        }
        
        public bool DeleteRole(int R_id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@R_id", R_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync
                ("Role_Package.DeleteRole", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }

       

        public List<Role> GetAllRole()
        {
            IEnumerable<Role> result = DbContext.Connection.Query<Role>
                 ("Role_Package.GetAllRole", commandType: CommandType.StoredProcedure);
            return result.ToList();

           
        }

        public List<GetRoleNameByIddto> GetRoleNameById(int R_id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("R_id", R_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetRoleNameByIddto> result = DbContext.Connection.Query<GetRoleNameByIddto>
                ("Role_Package.GetRoleNameById", parameter, commandType: CommandType.StoredProcedure);
            //return new api_course();
            return result.ToList();
        }

        public Role InsertRole(Role roles)
        {


            var parameter = new DynamicParameters();

            parameter.Add
                ("@R_name", roles.name, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = DbContext.Connection.ExecuteAsync
                ("Role_Package.InsertRole", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return roles;
        }

        public bool UpdateRole(Role roles)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@R_id", roles.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@R_name", roles.name, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = DbContext.Connection.ExecuteAsync
                ("Role_Package.UpdateRole", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;


            
        }
    }

}
