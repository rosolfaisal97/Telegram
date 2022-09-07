using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Telegram.Core.Common;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Infra.Repoisitory;

namespace Telegram.Infra.Repository
{
    public class UserRepoertRepository : IUserRepoertRepository
    {
        private readonly IDbContext _dbContext;
        public UserRepoertRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Delete(UserReportFormDTO userReport)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@p_rid", userReport.Id, dbType: DbType.Int32);
            _dbContext.Connection.Execute("report_user_package.Delete_report",
                                          parameter,
                                          commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<UserReportFormDTO> FilterByType(UserReportFormDTO form)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@p_type", form.Type, dbType: DbType.String);
            var result = _dbContext.Connection
                .Query<UserReportFormDTO>("report_user_package.Filter_By_Type",
                                          parameter,
                                          commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<UserReportDTO> GetAllUsersReports(int limit = 0, int count = 100)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@p_limit", limit, dbType: DbType.Int32);
            parameter.Add("@p_count", count, dbType: DbType.Int32);
            var result = _dbContext.Connection
                .Query<UserReportDTO>("report_user_package.Get_All_Reports",
                                          parameter,
                                          commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public UserReportDetailsDTO GetUserReportDetials(int userId)
        {
            //report id no userId
            var parameter = new DynamicParameters();
            parameter.Add("@p_rid", userId, dbType: DbType.Int32);
            var result = _dbContext.Connection
                .Query<UserReportDetailsDTO>("report_user_package.Get_user_report_info",
                                          parameter,
                                          commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public List<UserReportDetailsDTO> GetUserReports(int userToId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@p_user_to", userToId, dbType: DbType.Int32);
            var result = _dbContext.Connection
                .Query<UserReportDetailsDTO>("report_user_package.Get_All_user_Reports",
                                          parameter,
                                          commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool Insert(UserReportFormDTO userReport)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@p_user_from", userReport.UserFromId, dbType: DbType.Int32);
            parameter.Add("@p_user_to", userReport.UserToId, dbType: DbType.Int32);
            parameter.Add("@p_report_type", userReport.Type, dbType: DbType.String);
            parameter.Add("@p_report_text", userReport.Description, dbType: DbType.String);
            _dbContext.Connection
                .Execute("report_user_package.Insert_report",
                                          parameter,
                                          commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool Update(UserReportFormDTO userReport)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@p_rid", userReport.Id, dbType: DbType.Int32);
            parameter.Add("@p_is_accept", userReport.IsAccept, dbType: DbType.Int32);
            _dbContext.Connection
               .Execute("report_user_package.Update_report",
                                         parameter,
                                         commandType: CommandType.StoredProcedure);

            return true;
        }

        public int UserReportCount(int UserToId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@p_user_to", UserToId, dbType: DbType.Int32);
            var result = _dbContext.Connection
                .Query<int>("report_user_package.Count_user_Report",
                                          parameter,
                                          commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
