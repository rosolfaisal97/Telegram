using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class GroupLinkService : IGroupLinkService
    {
        private readonly IGroupLinkRepository groupLinkRepository;
        public GroupLinkService (IGroupLinkRepository _groupLinkRepository)
        {
            groupLinkRepository = _groupLinkRepository;
        }

        public bool CreateLinkGroup(GroupLink groupLink)
        {
            return groupLinkRepository.CreateLinkGroup(groupLink);
        }

        public bool DeleteLinkGroup(GroupLink groupLink)
        {
            return groupLinkRepository.DeleteLinkGroup(groupLink);
        }

        public List<GroupLink> GetAllLinkGroup()
        {
            return groupLinkRepository.GetAllLinkGroup();
        }

        public bool UpdateLinkGroup(GroupLink groupLink)
        {
            return groupLinkRepository.UpdateLinkGroup(groupLink);
        }
    }
}
