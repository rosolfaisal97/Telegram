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


        List<GroupAdmin> AdminsGroupName(AdminsGroupNameDto adminsGroupNameDto);
        List<Groups> OwnergrouplName(OwnergrouplNameDto ownergrouplNameDto);
        List<GroupMember> groupMember(GroupMemberDto groupMemberDto);


        List<Groups> SearchGroupUserChannel(SearchGroupDto groupDto);


    }
}
