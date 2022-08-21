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

        public AuthLoginDTO AuthLogin(AuthLoginDTO login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("L_username", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("L_password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<AuthLoginDTO> result = DbContext
                .Connection
                .Query<AuthLoginDTO>("login_Package.AuthLogin",
                                      parameter,
                                      commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool DeleteLogin(Login login)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@L_id",login.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
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

        public Login InsertLogin(Login login)
        {
            var parameter = new DynamicParameters();
            
            parameter.Add
                ("L_username", login.username, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add
                ("L_password", login.password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("L_phone", login.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("L_email", login.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("L_role_id", login.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync
                ("Login_Package.InsertLogin", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return login;
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

        public bool UpdateLogin(Login login)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@L_id", login.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("L_username", login.username, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add
                ("L_password", login.password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("L_phone", login.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("L_email", login.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("L_role_id", login.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync
                ("Login_Package.UpdateLogin", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

    }
}
