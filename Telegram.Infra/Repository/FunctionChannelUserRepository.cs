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
    public class FunctionChannelUserRepository : IFunctionChannelUserRepository
    {

        private readonly IDbContext DbContext;
        public FunctionChannelUserRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public List<AdminsChannelName> GetAdminsChannelName(int Cid)
        {

            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AdminsChannelName> result = DbContext.Connection.Query<AdminsChannelName>("Function_Channel_User_Package.AdminsChannelName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ChannelFiles> GetChannelFiles(int Cid)
        {
            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ChannelFiles> result = DbContext.Connection.Query<ChannelFiles>("Function_Channel_User_Package.ChannelFiles", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<MemberChannel> GetChannelMember(int Cid)
        {
            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<MemberChannel> result = DbContext.Connection.Query<MemberChannel>("Function_Channel_User_Package.ChannelMember", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ChannelPosts> GetChannelPosts(int Cid)
        {
            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ChannelPosts> result = DbContext.Connection.Query<ChannelPosts>("Function_Channel_User_Package.ChannelPosts", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ChannelProfile> GetChannelProfile(int Cid)
        {

            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ChannelProfile> result = DbContext.Connection.Query<ChannelProfile>("Function_Channel_User_Package.ChannelProfile", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CheckReprort> GetCheckReprort(int Rid)
        {
            var p = new DynamicParameters();
            p.Add("@Rid", Rid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CheckReprort> result = DbContext.Connection.Query<CheckReprort>("Function_Channel_User_Package.CheckReprort", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CommentPost> GetCommentPost(int Pid)
        {

            var p = new DynamicParameters();
            p.Add("@pid", Pid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CommentPost> result = DbContext.Connection.Query<CommentPost>("Function_Channel_User_Package.CommentPost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountAdminsChannel> GetCountAdminsChannel(int Cid)
        {

            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountAdminsChannel> result = DbContext.Connection.Query<CountAdminsChannel>("Function_Channel_User_Package.ChannelMember", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountChannelFiles> GetCountChannelFiles(int Cid)
        {

            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountChannelFiles> result = DbContext.Connection.Query<CountChannelFiles>("Function_Channel_User_Package.CountChannelFiles", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountChannelMember> GetCountChannelMember(int Cid)
        {

            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountChannelMember> result = DbContext.Connection.Query<CountChannelMember>("Function_Channel_User_Package.CountChannelMember", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountChannelPosts> GetCountChannelPosts(int Cid)
        {
            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountChannelPosts> result = DbContext.Connection.Query<CountChannelPosts>("Function_Channel_User_Package.CountChannelPosts", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountCommentPost> GetCountCommentPost(int Pid)
        {

            var p = new DynamicParameters();
            p.Add("@pid", Pid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountCommentPost> result = DbContext.Connection.Query<CountCommentPost>("Function_Channel_User_Package.CountCommentPost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountLikePost> GetCountLikePost(int Pid)
        {

            var p = new DynamicParameters();
            p.Add("@pid", Pid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountLikePost> result = DbContext.Connection.Query<CountLikePost>("Function_Channel_User_Package.CountLikePost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<FilesPost> GetFilesPost(int Cid)
        {

            var p = new DynamicParameters();
            p.Add("@pid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<FilesPost> result = DbContext.Connection.Query<FilesPost>("Function_Channel_User_Package.FilesPost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<FilterChannelByMember> GetFilterChannelByMember(FilterChannelByMember filterChannelByMember)
        {
            var p = new DynamicParameters();
            p.Add("@Chid", filterChannelByMember.CHid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@fName", filterChannelByMember.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@mname", filterChannelByMember.MiddleName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@lname", filterChannelByMember.LastName, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<FilterChannelByMember> result = DbContext.Connection.Query<FilterChannelByMember>("Function_Channel_User_Package.FilterChannelByMember", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<FilterChannelPost> GetFilterChannelPost(FilterChannelPost filterChannel)
        {
            var p = new DynamicParameters();
            p.Add("@Chid", filterChannel.CHid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pcontent", filterChannel.content, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<FilterChannelPost> result = DbContext.Connection.Query<FilterChannelPost>("Function_Channel_User_Package.FilterChannelPost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<LikePost> GetLikePost(int Pid)
        {

            var p = new DynamicParameters();
            p.Add("@pid", Pid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<LikePost> result = DbContext.Connection.Query<LikePost>("Function_Channel_User_Package.LikePost", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<OwnerChannelName> GetOwnerChannelName(int Cid)
        {
            var p = new DynamicParameters();
            p.Add("@Chid", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OwnerChannelName> result = DbContext.Connection.Query<OwnerChannelName>("Function_Channel_User_Package.OwnerChannelName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<PostReprortInfo> GetPostReprortInfo(int Rid)
        {

            var p = new DynamicParameters();
            p.Add("@Rid", Rid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PostReprortInfo> result = DbContext.Connection.Query<PostReprortInfo>("Function_Channel_User_Package.PostReprortInfo", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
