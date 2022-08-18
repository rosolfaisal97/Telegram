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
    public class MediaGroupRepositery : IMediaGroupRepositery
    {
        private readonly IDbContext DbContext;

        public MediaGroupRepositery(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CreateMediaGroup(MediaGroup mediaGroup)
        {
            var p = new DynamicParameters();
            p.Add("@cFile_path", mediaGroup.file_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cCaption", mediaGroup.caption, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cGroup_Message_id", mediaGroup.group_message_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupMedia_Package.CreateMediaGroup", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteMediaGroup(int id)
        {
            var p = new DynamicParameters();
            p.Add("@cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Group_Package.DeleteMediaGroup", p, commandType: CommandType.StoredProcedure);
            return true; ;
        }

        public List<MediaGroup> GetAllMediaGroup()
        {
            IEnumerable<MediaGroup> result = DbContext.Connection.Query<MediaGroup>("Group_Package.GetAllMediaGroup", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateMediaGroup(MediaGroup mediaGroup)
        {
            var p = new DynamicParameters();
            p.Add("@cid", mediaGroup.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cFile_path", mediaGroup.file_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cCaption", mediaGroup.caption, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cGroup_Message_id", mediaGroup.group_message_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("GroupMedia_Package.UpdateMediaGroup", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
