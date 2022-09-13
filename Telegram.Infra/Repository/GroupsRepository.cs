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
    public class GroupsRepository : IGroupsRepository
    {
        private readonly IDbContext DbContext;

        public GroupsRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CreateGroups(Groups groups)
        {
            var p = new DynamicParameters();
            p.Add("@cname", groups.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cowner_id", groups.owner_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cbio", groups.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cimagepath", groups.image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@p_GROUP_ID", Guid.NewGuid().ToString("N") , dbType: DbType.String);
            var result = DbContext.Connection.ExecuteAsync("Group_Package.CreateGroup", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteGroups(Groups groups)
        {
            var p = new DynamicParameters();
            p.Add("@cid", groups.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Group_Package.DeleteGroup", p, commandType: CommandType.StoredProcedure);
            return true; ;
        }

      

        

        public bool UpdateGroups(Groups groups)
        {
            var p = new DynamicParameters();
            p.Add("@cid", groups.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cname", groups.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cowner_id", groups.owner_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cbio", groups.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cimagepath", groups.image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Group_Package.UpdateGroup", p, commandType: CommandType.StoredProcedure);
            return true;
        }




        public List<Groups> GetAllGroups()
        {
            IEnumerable<Groups> result = DbContext.Connection.Query<Groups>("Group_Package.GetAllGroup", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }











        // Dto  list

        public List<GroupsInfoDto> GetGroupsInfo()
        {
            IEnumerable<GroupsInfoDto> result = DbContext.Connection.Query<GroupsInfoDto>("Fun_GroupAdmin_Package.GetGroupsInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountUserAdminForgroupDto> CountUserAdminForgroup()
        {
            IEnumerable<CountUserAdminForgroupDto> result = DbContext.Connection.Query<CountUserAdminForgroupDto>("Fun_GroupAdmin_Package.CountUserAdminForgroup", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountMemberEachgroupDto> CountMemberEachgroup()
        {
            IEnumerable<CountMemberEachgroupDto> result = DbContext.Connection.Query<CountMemberEachgroupDto>("Fun_GroupAdmin_Package.CountMemberEachgroup", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<GroupAdmin> GetNameAdminGroup(GetNameAdminGroupDto getNameAdminGroupDto)
        {
            var p = new DynamicParameters(); 
            p.Add("@A_id", getNameAdminGroupDto.id, dbType:DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GroupAdmin> result = DbContext.Connection.Query<GroupAdmin>("Fun_GroupAdmin_Package.GetNameAdminGroup", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<MediaGroup> GetMediaEachgroup(GetMediaEachgroupDto getMediaEachgroupDto)
        {
            var p = new DynamicParameters();
            p.Add("@gr_id", getMediaEachgroupDto.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<MediaGroup> result = DbContext.Connection.Query<MediaGroup>("Fun_GroupAdmin_Package.GetMediaEachgroup", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<MediaGroup> CountMediaEachgroup(CountMediaEachgroupDto countMediaEachgroupDto)
        {
            var p = new DynamicParameters();
            p.Add("@gr_id", countMediaEachgroupDto.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<MediaGroup> result = DbContext.Connection.Query<MediaGroup>("Fun_GroupAdmin_Package.CountMediaEachgroup", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<AdminsGroupNameDto> AdminsGroupName(int Gid)
        {
            var p = new DynamicParameters();
            p.Add("@groid", Gid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AdminsGroupNameDto> result = DbContext.Connection.Query<AdminsGroupNameDto>("Fun_GroupUser_Package.AdminsGroupName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<OwnergrouplNameDto> OwnergrouplName(int Gid)
        {
            var p = new DynamicParameters();
            p.Add("@groid", Gid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OwnergrouplNameDto> result = DbContext.Connection.Query<OwnergrouplNameDto>("Fun_GroupUser_Package.OwnergrouplName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<GroupMemberDto> groupMember(int Gid)
        {
            var p = new DynamicParameters();
            p.Add("@groid", Gid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GroupMemberDto> result = DbContext.Connection.Query<GroupMemberDto>("Fun_GroupUser_Package.groupMember", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Groups> SearchGroupUserChannel(SearchGroupDto groupDto)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("nameGroup", groupDto.nameGroup, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Groups> result = DbContext.Connection.Query<Groups>
                           ("Group_Package.SearchGroupUserChannel", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }







        // end Dto list
    }
    }
