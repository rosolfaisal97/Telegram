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
    public class StoryRepo : IStory
    {
        private readonly IDbContext DbContext;

        public StoryRepo(IDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public bool DeleteStory(int S_id)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                 ("@S_id", S_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync
                ("story_Package.DeleteStory", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<Story> GetAllStory()
        {
            IEnumerable<Story> result = DbContext.Connection.Query<Story>
                 ("story_Package.GetAllStory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Story InsertStory(Story story)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("S_content", story.content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("S_file_path", story.file_path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("S_user_id", story.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("S_created_at", story.created_at, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            

            var result = DbContext.Connection.ExecuteAsync
                ("story_Package.InsertStory", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return story;
        }

        public List<ReturnUserInfodto> ReturnUserInfo(int S_user_id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("S_user_id", S_user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<ReturnUserInfodto> result = DbContext.Connection.Query<ReturnUserInfodto>("story_Package.ReturnUserInfo", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool UpdateStory(Story story)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("S_id", story.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("S_content", story.content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("S_file_path", story.file_path, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("S_user_id", story.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("S_created_at", story.created_at, dbType: DbType.DateTime, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync
                ("story_Package.UpdateStory", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
    }
}
