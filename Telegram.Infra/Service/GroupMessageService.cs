using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class GroupMessageService : IGroupMessageService
    {
        private readonly IGroupMessageRepositoty groupMessageRepositoty;
        public GroupMessageService(IGroupMessageRepositoty _groupMessageRepositoty)
        {
            groupMessageRepositoty = _groupMessageRepositoty;
        }
        public bool CreateGroupMessage(GroupMessage groupMessage)
        {
            return groupMessageRepositoty.CreateGroupMessage(groupMessage);
        }

        public bool DeleteGroupMessage(int id)
        {
            return groupMessageRepositoty.DeleteGroupMessage(id);
        }

        public List<GroupMessage> GetAllGroupMessage()
        {
            return groupMessageRepositoty.GetAllGroupMessage();
        }

        public bool UpdateGroupMessage(GroupMessage groupMessage)
        {
            throw new NotImplementedException();
        }
    }
}
