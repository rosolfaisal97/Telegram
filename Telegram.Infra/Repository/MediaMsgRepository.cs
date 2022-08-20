using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repository
{
    public class MediaMsgRepository : IMediaMsgRepository
    {
        private readonly IDbContext _dbContext;
        public MediaMsgRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteMedia(int msgId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@p_id", msgId, dbType: DbType.Int32);
            _dbContext.Connection
                .ExecuteAsync("Package_media_message.MEDIA_MESSAGE_DELETE",
                              parameters,
                              commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<MediaMessage> GetAllMsgMedia(int msgId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@p_message_id", msgId, dbType: DbType.Int32);
          
            var result=_dbContext.Connection
                .QueryAsync<MediaMessage>("Package_media_message.Get_All_message_media",
                              parameters,
                              commandType: CommandType.StoredProcedure);

            return result.Result.ToList();
        }

        public bool InsertMedia(string filePath, string caption, int msgId)
        {
            var parameters = new DynamicParameters();
            parameters.Add(name: "@p_file_path", filePath, dbType: DbType.Int32);
            parameters.Add(name: "@p_caption", caption, dbType: DbType.Int32);
            parameters.Add(name: "@p_message_id", msgId, dbType: DbType.Int32);
            _dbContext.Connection
                .ExecuteAsync("Package_media_message.media_message_insert",
                              parameters,
                              commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
