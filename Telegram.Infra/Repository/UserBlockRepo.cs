using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MimeKit;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repoisitory
{
    public class UserBlockRepo : IUserBlockList
    {
        private readonly IDbContext DbContext;

        public UserBlockRepo(IDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public bool DeleteUserBlock(UserBlockList userBlock)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@UB_id",userBlock.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync
                ("user_block_Package.DeleteUserBlock", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<UserBlockList> GetAllUserBlock()
        {
            IEnumerable<UserBlockList> result = DbContext.Connection.Query<UserBlockList>
                   ("user_block_Package.GetAllUserBlock", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public UserBlockList InsertUserBlock(UserBlockList userBlock)
        {
                var parameter = new DynamicParameters();

            parameter.Add
                ("UB_user_from",userBlock.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("UB_user_to",userBlock.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
        

            var result = DbContext.Connection.ExecuteAsync
                ("user_block_Package.InsertUserBlock", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return userBlock;
        }

        public List<My_block_ListDTO> My_block_List(UserBlockList userBlock)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@user_id",userBlock.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<My_block_ListDTO> result = DbContext.Connection.Query<My_block_ListDTO>
                                       ("user_block_Package.My_block_List", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateUserBlock(UserBlockList userBlock)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@UB_id",userBlock.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("UB_user_from",userBlock.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("UB_user_to",userBlock.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync
                ("user_block_Package.UpdateUserBlock", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

        public List<GetAllBlockUserAndSendEmailDTO> GetAllBlockUserAndSendEmail()
        {
            
            IEnumerable<GetAllBlockUserAndSendEmailDTO> result = DbContext.Connection.Query<GetAllBlockUserAndSendEmailDTO>
                                       ("user_block_Package.GetAllBlockUserAndSendEmail", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool EmailSend(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<EmailSendDTO> result = DbContext.Connection.Query<EmailSendDTO>("user_block_Package.EmailSend", parameter, commandType: CommandType.StoredProcedure);
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", "newqroma@gmail.com");
            MailboxAddress to = new MailboxAddress("user", result.FirstOrDefault().email);
            builder.HtmlBody = "Hi " + result.FirstOrDefault().NameUserto+" " + result.FirstOrDefault().LastNameto + 
                " You are blocked from " + result.FirstOrDefault().NameUserfrom + " " + result.FirstOrDefault().LastNamefrom + " . ";
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
