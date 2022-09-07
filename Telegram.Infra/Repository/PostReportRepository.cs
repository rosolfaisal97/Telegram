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
    public class PostReportRepository: IPostReportRepository
    {

        private readonly IDbContext DbContext;
        public PostReportRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public List<ReportPostJoinDto> AllReportPost()
        {
            IEnumerable<ReportPostJoinDto> result = DbContext.Connection.Query<ReportPostJoinDto>("Report_Post_Package.AllReportPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreatePostReport(ReportPost report_Post)
        {
            var p = new DynamicParameters();
            p.Add("@Fuser", report_Post.user_from, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@P_id", report_Post.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@typee", report_Post.type, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@descript", report_Post.description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@accepting", report_Post.is_accept, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Report_Post_Package.InsertReportPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeletePostReport(int id)
        {
            var p = new DynamicParameters();
            p.Add("@RP_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Report_Post_Package.DeleteReportPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ReportPost> GetAllPostReport()
        {
            IEnumerable<ReportPost> result = DbContext.Connection.Query<ReportPost>("Report_Post_Package.GetAllReportPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdatePostReport(ReportPost report_Post)
        {
            var p = new DynamicParameters();
            p.Add("@RP_id", report_Post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Fuser", report_Post.user_from, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@P_id", report_Post.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@typee", report_Post.type, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@descript", report_Post.description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@accepting", report_Post.is_accept, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Report_Post_Package.UpdateReportPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
