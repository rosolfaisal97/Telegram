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
    public class UserRepo : Iusers
    {
        private readonly IDbContext DbContext;

        public UserRepo(IDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public bool DeleteUsers(int U_id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@U_id", U_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync
                ("Users_Package.DeleteUsers", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<User> GetAllUsers()
        {
            IEnumerable<User> result = DbContext.Connection.Query<User>
                 ("Users_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public User InsertUsers(User uss)
        {
            var parameter = new DynamicParameters();
  
            parameter.Add
                ("U_first_name", uss.first_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_middle_name", uss.middle_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_last_name", uss.last_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_bio", uss.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_gender", uss.gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_image_path", uss.image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_login_id", uss.login_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            
            var result = DbContext.Connection.ExecuteAsync
                ("Users_Package.InsertUsers", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return uss;
        }

        public List<NumberOfUserdto> NumberOfUser()
        {
            IEnumerable<NumberOfUserdto> result = DbContext.Connection.Query<NumberOfUserdto>
                ("Users_Package.NumberOfUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<NumberOfUserByGenderdto> NumberOfUserByGender(string U_gender)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("U_gender",U_gender, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<NumberOfUserByGenderdto> result = DbContext.Connection.Query<NumberOfUserByGenderdto> 
                ("Users_Package.NumberOfUserByGender", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public InsertUsersRepo RegisterUser(InsertUsersRepo Ins)
        {

            var parameter = new DynamicParameters();

            parameter.Add
                ("U_first_name", Ins.U_first_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_middle_name", Ins.U_middle_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_last_name", Ins.U_last_name, dbType: DbType.String, direction: ParameterDirection.Input);
            
            parameter.Add
                ("U_gender", Ins.U_gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("L_username",Ins.L_username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("L_password", Ins.L_password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("L_email", Ins.L_email, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync
                ("Users_Package.RegisterUser", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return Ins;
        }


        public List<SearchUserInfo> SarchUserInfo(string sarch)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("sarch", sarch, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<SearchUserInfo> result = DbContext.Connection.Query<SearchUserInfo>("Users_Package.SarchUserInfo", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(DateTime dateto, DateTime datefrom)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("dateto", dateto, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
                ("datefrom", datefrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<SearchButweenTwoDatedto> result = DbContext.Connection.Query<SearchButweenTwoDatedto>
                           ("Users_Package.SearchButweenTwoDate", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateProfileUser(UpdateProfileUserDTO Upd)
        {

          
             var parameter = new DynamicParameters();
            parameter.Add
                ("@U_id", Upd.U_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("U_first_name", Upd.U_first_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_middle_name", Upd.U_middle_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_last_name", Upd.U_last_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_gender", Upd.U_gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_image_path", Upd.U_image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("L_email", Upd.L_email, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add
               ("L_phone", Upd.L_phone, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync
                ("Users_Package.UpdateProfileUser", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

        public bool UpdateUsers(User uss)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@U_id", uss.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("U_first_name", uss.first_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_middle_name", uss.middle_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_last_name", uss.last_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_bio", uss.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_gender", uss.gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_image_path", uss.image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_login_id", uss.login_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("U_is_blocked", uss.is_blocked, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync
                ("Users_Package.UpdateUsers", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;

        }






        public List<AdminBlockDto> AdminBlock(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("CUserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<AdminBlockDto> result = DbContext.Connection.Query<AdminBlockDto>("Users_Package.CreateAdminBlock", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<AdminBlockDto> GetAllUsersBlocked()
        {
            IEnumerable<AdminBlockDto> result = DbContext.Connection.Query<AdminBlockDto>
                ("Users_Package.GetAllUsersBlockAdmin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<User> CheckStatusBlock(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@CUserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<User> result = DbContext.Connection.Query<User>("Users_Package.CheckStatusBlock", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
