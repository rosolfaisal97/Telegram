using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telegram.Core.Common;
using Telegram.Core.DTO;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repository
{
    public class FunctionChannelAdminRepository : IFunctionChannelAdminRepository
    {
        private readonly IDbContext DbContext;
        public FunctionChannelAdminRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public List<ChannelNameUserAdmin> GetChannelNameUserAdmin(int Aid)
        {
            var p = new DynamicParameters();
            p.Add("@A_id", Aid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ChannelNameUserAdmin> result = DbContext.Connection.Query<ChannelNameUserAdmin>("Function_Channel_Admin_Package.ChannelNameUserAdmin", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<GetChannelPosts> GetChannelPosts(int CHid)
        {
            var p = new DynamicParameters();
            p.Add("@Chid", CHid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetChannelPosts> result = DbContext.Connection.Query<GetChannelPosts>("Function_Channel_Admin_Package.GetChannelPosts", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ChannelsInfo> GetChannelsInfo()
        {
            IEnumerable<ChannelsInfo> result = DbContext.Connection.Query<ChannelsInfo>("Function_Channel_Admin_Package.ChannelsInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountFilterReportPostByType> GetCountFilterReportPostByType()
        {
            IEnumerable<CountFilterReportPostByType> result = DbContext.Connection.Query<CountFilterReportPostByType>("Function_Channel_Admin_Package.CountFilterReportPostByType", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountMediaEachChannel> GetCountMediaEachChannel(int CHid)
        {
            var p = new DynamicParameters();
            p.Add("@CH_id", CHid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountMediaEachChannel> result = DbContext.Connection.Query<CountMediaEachChannel>("Function_Channel_Admin_Package.CountMediaEachChannel", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountMemberEachChannel> GetCountMemberEachChannel()
        {
            IEnumerable<CountMemberEachChannel> result = DbContext.Connection.Query<CountMemberEachChannel>("Function_Channel_Admin_Package.CountMemberEachChannel", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountPostEachChannel> GetCountPostEachChannel()
        {
            IEnumerable<CountPostEachChannel> result = DbContext.Connection.Query<CountPostEachChannel>("Function_Channel_Admin_Package.CountPostEachChannel", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountReportAcceptEachPost> GetCountReportAcceptEachPost(int Pid)
        {
            var p = new DynamicParameters();
            p.Add("@P_id", Pid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountReportAcceptEachPost> result = DbContext.Connection.Query<CountReportAcceptEachPost>("Function_Channel_Admin_Package.CountReportAcceptEachPost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountReportEachPost> GetCountReportEachPost()
        {
            IEnumerable<CountReportEachPost> result = DbContext.Connection.Query<CountReportEachPost>("Function_Channel_Admin_Package.CountReportEachPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountUserAdmin> GetCountUserAdmin()
        {
            IEnumerable<CountUserAdmin> result = DbContext.Connection.Query<CountUserAdmin>("Function_Channel_Admin_Package.CountUserAdmin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<FilterReportPostByType> GetFilterReportPostByType(FilterReportPostByType RType)
        {

            var p = new DynamicParameters();
            p.Add("@t_R", RType.type, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<FilterReportPostByType> result = DbContext.Connection.Query<FilterReportPostByType>("Function_Channel_Admin_Package.FilterReportPostByType", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<GetMediaEachChannel> GetMediaEachChannels(int CHid)
        {
            var p = new DynamicParameters();
            p.Add("@CH_id", CHid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetMediaEachChannel> result = DbContext.Connection.Query<GetMediaEachChannel>("Function_Channel_Admin_Package.GetMediaEachChannel", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<MostReportPost> GetMostReportPost()
        {
            IEnumerable<MostReportPost> result = DbContext.Connection.Query<MostReportPost>("Function_Channel_Admin_Package.MostReportPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ReportAcceptEachPost> GetReportAcceptEachPost(int Pid)
        {
            var p = new DynamicParameters();
            p.Add("@P_id", Pid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ReportAcceptEachPost> result = DbContext.Connection.Query<ReportAcceptEachPost>("Function_Channel_Admin_Package.ReportAcceptEachPost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ReportEachPost> GetReportEachPost(int Pid)
        {
            var p = new DynamicParameters();
            p.Add("@P_id", Pid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ReportEachPost> result = DbContext.Connection.Query<ReportEachPost>("Function_Channel_Admin_Package.ReportEachPost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Top10PostByComment> GetTop10PostByComment()
        {
            IEnumerable<Top10PostByComment> result = DbContext.Connection.Query<Top10PostByComment>("Function_Channel_Admin_Package.Top10PostByComment", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Top10PostByLike> GetTop10PostByLike()
        {
            IEnumerable<Top10PostByLike> result = DbContext.Connection.Query<Top10PostByLike>("Function_Channel_Admin_Package.Top10PostByLike", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
