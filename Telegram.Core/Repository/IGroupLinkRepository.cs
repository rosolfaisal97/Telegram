using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Repository
{
    public interface IGroupLinkRepository
    {

        bool CreateLinkGroup(GroupLink groupLink);
        List<GroupLink> GetAllLinkGroup();
        bool UpdateLinkGroup(GroupLink groupLink);
        bool DeleteLinkGroup(int id);
    }
}
