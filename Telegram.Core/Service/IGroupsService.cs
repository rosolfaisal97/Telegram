using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IGroupsService
    {
        bool CreateGroups(Groups groups);
        List<Groups> GetAllGroups();
        bool UpdateGroups(Groups groups);
        bool DeleteGroups(Groups groups);




        List<GroupsInfoDto> GetGroupsInfo();
        List<CountUserAdminForgroupDto> CountUserAdminForgroup();
        List<CountMemberEachgroupDto> CountMemberEachgroup();
        List<GroupAdmin> GetNameAdminGroup(GetNameAdminGroupDto getNameAdminGroupDto);
        List<MediaGroup> GetMediaEachgroup(GetMediaEachgroupDto getMediaEachgroupDto);
        List<MediaGroup> CountMediaEachgroup(CountMediaEachgroupDto countMediaEachgroupDto);


        List<AdminsGroupNameDto> AdminsGroupName(int Gid);
        List<OwnergrouplNameDto> OwnergrouplName(int Gid);
        List<GroupMemberDto> groupMember(int Gid);


        List<Groups> SearchGroupUserChannel(SearchGroupDto groupDto);


    }
}
