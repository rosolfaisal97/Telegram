using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IGroupMemberService
    {
        bool CreateGroupMember(GroupMember groupMember);
        List<GroupMember> GetAllGroupMember();
        bool UpdateGroupMember(GroupMember groupMember);
        bool DeleteGroupMember(GroupMember groupMember);
    }
}
