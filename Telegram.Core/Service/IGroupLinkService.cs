using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IGroupLinkService
    {
        bool CreateLinkGroup(GroupLink groupLink);
        List<GroupLink> GetAllLinkGroup();
        bool UpdateLinkGroup(GroupLink groupLink);
        bool DeleteLinkGroup(GroupLink groupLink);
    }
}
