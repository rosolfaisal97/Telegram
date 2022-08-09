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
    public class PostMediaRepository: IPostMediaRepository
    {
        private readonly IDbContext DbContext;
        public PostMediaRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool CreatePostMedia(MediaPost media_Post)
        {
            var p = new DynamicParameters();
            p.Add("@Fpath", media_Post.file_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@P_id", media_Post.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Media_Post_Package.InsertMediaPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeletePostMedia(int id)
        {
            var p = new DynamicParameters();
            p.Add("@MP_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Media_Post_Package.DeleteMediaPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<MediaPost> GetAllPostMedia()
        {
            IEnumerable<MediaPost> result = DbContext.Connection.Query<MediaPost>("Media_Post_Package.GetAllMediaPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdatePostMedia(MediaPost media_Post)
        {
            var p = new DynamicParameters();
            p.Add("@MP_id", media_Post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@Fpath", media_Post.file_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@P_id", media_Post.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Media_Post_Package.UpdateMediaPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
