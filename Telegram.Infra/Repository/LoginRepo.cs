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
    public class LoginRepo : ILogin
    {
        private readonly IDbContext DbContext;

        public LoginRepo(IDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public AuthLoginREPO AuthLogin(AuthLoginREPO login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("L_username", login.L_username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("L_password", login.L_password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<AuthLoginREPO> result = DbContext.Connection.Query<AuthLoginREPO>("login_Package.AuthLogin", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool DeleteLogin(int L_id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@L_id", L_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync
                ("login_Package.DeleteLogin", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<Login> GetAllLogin()
        {
            IEnumerable<Login> result = DbContext.Connection.Query<Login>
                ("login_Package.GetAllLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Login InsertLogin(Login logins)
        {
            var parameter = new DynamicParameters();
            
            parameter.Add
                ("L_username", logins.username, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add
                ("L_password", logins.password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("L_phone", logins.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("L_email", logins.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("L_role_id", logins.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync
                ("Login_Package.InsertLogin", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return logins;
        }

        public bool RePasswordUser(RePasswordUserrEPO rep)
        {
            var parameter = new DynamicParameters();
            parameter.Add("L_id", rep.L_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("L_password",rep.L_password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<RePasswordUserrEPO> result = DbContext.Connection.Query<RePasswordUserrEPO>("login_Package.RePasswordUser", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateLogin(Login logins)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@L_id", logins.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("L_username", logins.username, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add
                ("L_password", logins.password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("L_phone", logins.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("L_email", logins.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("L_role_id", logins.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync
                ("Login_Package.UpdateLogin", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

    }
}
