using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class GroupsService : IGroupsService
    {
        private readonly IGroupsRepository groupsRepository;
        public GroupsService (IGroupsRepository _groupsRepository)
        {
            groupsRepository = _groupsRepository;
        }

        public List<GroupAdmin> AdminsGroupName(AdminsGroupNameDto adminsGroupNameDto)
        {
            return groupsRepository.AdminsGroupName(adminsGroupNameDto);

        }
        public List<MediaGroup> CountMediaEachgroup(CountMediaEachgroupDto countMediaEachgroupDto)
        {
                return groupsRepository.CountMediaEachgroup(countMediaEachgroupDto);
        }

        public List<CountMemberEachgroupDto> CountMemberEachgroup()
        {
            return groupsRepository.CountMemberEachgroup();
        }

        public List<CountUserAdminForgroupDto> CountUserAdminForgroup()
        {
            return groupsRepository.CountUserAdminForgroup();
        }

        public bool CreateGroups(Groups groups)
        {
            return groupsRepository.CreateGroups(groups);
        }

        public bool DeleteGroups(int id)
        {
            return groupsRepository.DeleteGroups(id);
        }

        public List<Groups> GetAllGroups()
        {
            return groupsRepository.GetAllGroups();
        }

        public List<GroupsInfoDto> GetGroupsInfo()
        {
            return groupsRepository.GetGroupsInfo();
        }

        public List<MediaGroup> GetMediaEachgroup(GetMediaEachgroupDto getMediaEachgroupDto)
        {
            return groupsRepository.GetMediaEachgroup(getMediaEachgroupDto);
        }

        public List<GroupAdmin> GetNameAdminGroup(GetNameAdminGroupDto getNameAdminGroupDto)
        {
            return groupsRepository.GetNameAdminGroup(getNameAdminGroupDto);
        }

        public List<GroupMember> groupMember(GroupMemberDto groupMemberDto)
        {
            return groupsRepository.groupMember(groupMemberDto);
        }

        public List<Groups> OwnergrouplName(OwnergrouplNameDto ownergrouplNameDto)
        {
            return groupsRepository.OwnergrouplName(ownergrouplNameDto);
        }

        public bool UpdateGroups(Groups groups)
        {
            return groupsRepository.UpdateGroups(groups);
        }
    }
}
