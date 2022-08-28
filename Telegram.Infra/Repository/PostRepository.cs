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
    public class PostRepository: IPostRepository
    {
        private readonly IDbContext DbContext;
        public PostRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool CreatePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@A_id", post.admin_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_id", post.channel_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_content", post.content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@P_id_Seq", post.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            

            var result = DbContext.Connection.ExecuteAsync("Post_Package.InsertPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeletePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@P_id",post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Post_Package.DeletePost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Post> GetAllPost()
        {
            IEnumerable<Post> result = DbContext.Connection.Query<Post>("Post_Package.GetAllPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdatePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@P_id", post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@A_id", post.admin_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_id", post.channel_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@C_content", post.content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@P_id_Seq", post.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Post_Package.UpdatePost", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
