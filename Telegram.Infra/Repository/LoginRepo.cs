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
                ("login_Package.InsertLogin", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return login;
        }

        public bool RePasswordUser(RePasswordDTO rePasswordDTO)
        {
            var parameter = new DynamicParameters();
            parameter.Add("L_id",rePasswordDTO.loginId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("L_password",rePasswordDTO.newPassword, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<RePasswordDTO> result = DbContext.Connection.Query<RePasswordDTO>("login_Package.RePasswordUser", parameter, commandType: CommandType.StoredProcedure);

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
                ("login_Package.UpdateLogin", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
        public bool ChackPassword(RePasswordDTO rePasswordDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userId", rePasswordDTO.loginId, DbType.Int32);
            parameters.Add("@oldPassword",rePasswordDTO.oldPassword, DbType.Int32);
            var result = DbContext.Connection.
               QueryAsync<int>("login_Package.ChackPassword",
                            parameters,
                            commandType: CommandType.StoredProcedure);
            if (result.Result.FirstOrDefault() > 0)
                return RePasswordUser(rePasswordDTO);
            return false;


        }

    }
}
