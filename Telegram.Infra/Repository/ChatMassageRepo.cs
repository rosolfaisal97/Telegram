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
    public class ChatMassageRepo : IChatMessage
    {
        private readonly IDbContext DbContext;

        public ChatMassageRepo(IDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public bool DeleteChatMessage(int? Ch__id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@Ch__id", Ch__id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync
                ("Chat_Message_Package.DeleteChatMessage", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<ChatMessage> GetAllChatMessage()
        {
            IEnumerable<ChatMessage> result = DbContext.Connection.Query<ChatMessage>
                 ("Chat_Message_Package.GetAllChatMessage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ChatMessage InsertChatMessage(ChatMessage chat)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("Ch_user_from", chat.user_from, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_user_to",chat.user_to, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_content", chat.content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_is_read", chat.is_read, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_created_at ", chat.created_at, dbType: DbType.DateTime, direction: ParameterDirection.Input);
          

            var result = DbContext.Connection.ExecuteAsync
                ("Chat_Message_Package.InsertChatMessage", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return chat;
        }

        public List<ReturnMassageInfodto> ReturnMassageInfo(ReturnMassageInfodto massage)
        {
            
            IEnumerable<ReturnMassageInfodto> result = DbContext.Connection.Query<ReturnMassageInfodto>
            ("Chat_Message_Package.ReturnMassageInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<SearchMassageInfodto> SearchMassageInfo(SearchMassageInfodto searchmassage)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("Ch_user_from", searchmassage.Ch_user_from, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_user_to", searchmassage.Ch_user_to, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
                ("search_m", searchmassage.search_m, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<SearchMassageInfodto> result = DbContext.Connection.Query<SearchMassageInfodto>
                           ("Chat_Message_Package.SearchMassageInfo", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateChatMessage(ChatMessage chat)
        {
            
            var parameter = new DynamicParameters();
            parameter.Add
                ("@Ch__id", chat.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_user_from", chat.user_from, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_user_to", chat.user_to, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_content", chat.content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_is_read", chat.is_read, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("Ch_created_at ", chat.created_at, dbType: DbType.DateTime, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync
                ("Chat_Message_Package.UpdateChatMessage", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;

        }
    }
}
