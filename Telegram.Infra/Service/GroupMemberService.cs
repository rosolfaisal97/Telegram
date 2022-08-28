using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepository  groupMemberRepository;
        public GroupMemberService (IGroupMemberRepository _groupMemberRepository)
        {
            groupMemberRepository = _groupMemberRepository;
        }

        public bool CreateGroupMember(GroupMember groupMember)
        {
            return groupMemberRepository.CreateGroupMember(groupMember);
        }

        public bool DeleteGroupMember(GroupMember groupMember)
        {
            return groupMemberRepository.DeleteGroupMember(groupMember);
        }

        public List<GroupMember> GetAllGroupMember()
        {
            return groupMemberRepository.GetAllGroupMember();
        }

        public bool UpdateGroupMember(GroupMember groupMember)
        {
            return groupMemberRepository.UpdateGroupMember(groupMember);
        }
    }
}
