using Dapper;
using MimeKit;
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
        public bool DeleteUsers(User user)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@U_id",user.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
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

        public User InsertUsers(User user)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("U_first_name", user.first_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_middle_name", user.middle_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_last_name", user.last_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_bio", user.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_gender", user.gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_image_path", user.image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
 
                ("U_login_id", user.login_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            
 
            var result = DbContext.Connection.ExecuteAsync
                ("Users_Package.InsertUsers", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return user;
        }

        public List<NumberOfUserdto> NumberOfUser()
        {
            IEnumerable<NumberOfUserdto> result = DbContext.Connection.Query<NumberOfUserdto>
                ("Users_Package.NumberOfUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<NumberOfUserByGenderdto> NumberOfUserByGender(User user)
        {
            var parameter = new DynamicParameters();

            parameter.Add
 
                ("U_gender", user.gender, dbType: DbType.String, direction: ParameterDirection.Input);
 

            IEnumerable<NumberOfUserByGenderdto> result = DbContext.Connection.Query<NumberOfUserByGenderdto>
                ("Users_Package.NumberOfUserByGender", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public InsertUsersRepo RegisterUser(InsertUsersRepo InsertUser)
        {

            var parameter = new DynamicParameters();

            parameter.Add
                ("U_first_name", InsertUser.U_first_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_middle_name", InsertUser.U_middle_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
 
                ("U_last_name", InsertUser.U_last_name, dbType: DbType.String, direction: ParameterDirection.Input);
            
 
            parameter.Add
                ("U_gender", InsertUser.U_gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
 
                ("L_username", InsertUser.L_username, dbType: DbType.String, direction: ParameterDirection.Input);
 
            parameter.Add
               ("L_password", InsertUser.L_password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("L_email", InsertUser.L_email, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync
                ("Users_Package.RegisterUser", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return InsertUser;
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

        public bool UpdateProfileUser(UpdateProfileUserDTO UpdateUser)
        {


            var parameter = new DynamicParameters();
            parameter.Add
                ("@U_id",UpdateUser.U_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@U_first_name",UpdateUser.U_first_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@U_middle_name",UpdateUser.U_middle_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@U_last_name",UpdateUser.U_last_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@U_gender",UpdateUser.U_gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@U_image_path",UpdateUser.U_image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@L_email",UpdateUser.L_email, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add
               ("@L_phone",UpdateUser.L_phone, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync
                ("Users_Package.UpdateProfileUser", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

        public bool UpdateUsers(User user)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@U_id", user.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("U_first_name", user.first_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_middle_name", user.middle_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_last_name", user.last_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_bio", user.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_gender", user.gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("U_image_path", user.image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                 ("U_login_id", user.login_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("U_is_blocked", user.is_blocked, dbType: DbType.Int32, direction: ParameterDirection.Input);
 
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
         public GetUserByIdDto GetUserById(int U_id)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@U_id", U_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetUserByIdDto> result = DbContext.Connection.Query<GetUserByIdDto>
                 ("Users_Package.GetUserById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool EmailSenduserblock(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<EmailSenduserblockDTO> result = DbContext.Connection.Query<EmailSenduserblockDTO>("Users_Package.EmailSenduserblock", parameter, commandType: CommandType.StoredProcedure);
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", "newqroma@gmail.com");
            MailboxAddress to = new MailboxAddress("user", result.FirstOrDefault().email);
            if(result.FirstOrDefault().block == 1)
            {
                builder.HtmlBody = "Hi " + result.FirstOrDefault().NameUserto + " " + result.FirstOrDefault().LastNameto +
                " You are blocked from Telegram . ";
            }else if(result.FirstOrDefault().block == 0)
            {
                builder.HtmlBody = "Hi " + result.FirstOrDefault().NameUserto + " " + result.FirstOrDefault().LastNameto +
                " You have been unblocked from Telegram . ";

            }
            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "Blocked group";
            using (var item = new MailKit.Net.Smtp.SmtpClient())
            {
                item.Connect("smtp.gmail.com", 587, false);
                item.Authenticate("newqroma@gmail.com", "cfodqutfkmzlouut");
                item.Send(message);
                item.Disconnect(true);

            }
            //return result;
            return true;
        }

    }
}
