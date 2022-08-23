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

namespace Telegram.Infra.Repository
{
    public class StoryReportRepository : IStoryReportRepository
    {
        private readonly IDbContext DbContext;
        public StoryReportRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool Delete_report(ReportStory reportStory)
        {
            var p = new DynamicParameters();
            p.Add("@p_rid", reportStory.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("report_story_package.Delete_report", p, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

        public List<GetAllReportStory> Get_All_Reports()
        {


            IEnumerable<GetAllReportStory> result = DbContext.Connection.Query<GetAllReportStory>
                 ("report_story_package.Get_All_Reports", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ReportStory Insert_story(ReportStory reportStory)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@p_user_id", reportStory.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@p_story_id", reportStory.story_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@p_report_type", reportStory.Type, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@p_report_text", reportStory.description, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = DbContext.Connection.ExecuteAsync
                ("report_story_package.Insert_story", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return reportStory;
        }

        public bool Update_report(ReportStory reportStory)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@p_rid", reportStory.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@p_is_accept", reportStory.is_accept, dbType: DbType.Int32, direction: ParameterDirection.Input);




            var result = DbContext.Connection.ExecuteAsync
                ("report_story_package.Update_report", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

        public List<GetAllStoryRepoDto> Get_All_story_Reports(int p_story_id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@p_story_id", p_story_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<GetAllStoryRepoDto> result = DbContext.Connection.Query<GetAllStoryRepoDto>
                 ("report_story_package.Get_All_story_Reports", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public List<FilterByTypeDto> Filter_By_Type(string p_type)
{
        var parameter = new DynamicParameters();

        parameter.Add
                ("@p_type", p_type, dbType: DbType.Int32, direction: ParameterDirection.Input);
            

            IEnumerable<FilterByTypeDto> result = DbContext.Connection.Query<FilterByTypeDto>
                 ("report_story_package.Filter_By_Type", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<CountStoryReport> Count_story_Report(int p_story_id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                    ("@p_story_id", p_story_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<CountStoryReport> result = DbContext.Connection.Query<CountStoryReport>
                 ("report_story_package.Count_story_Report", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


    }
}
