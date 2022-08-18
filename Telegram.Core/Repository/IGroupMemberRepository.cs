using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Repository
{
    public interface IGroupMemberRepository
    {
        bool CreateGroupMember(GroupMember groupMember);
        List<GroupMember> GetAllGroupMember();
        bool UpdateGroupMember(GroupMember groupMember);
        bool DeleteGroupMember(int id);
    }
}
