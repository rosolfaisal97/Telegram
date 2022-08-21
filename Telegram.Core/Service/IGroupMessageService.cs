﻿using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IGroupMessageService
    {
        bool CreateGroupMessage(GroupMessage groupMessage);
        List<GroupMessage> GetAllGroupMessage();
        bool UpdateGroupMessage(GroupMessage groupMessage);
        bool DeleteGroupMessage(GroupMessage groupMessage);
    }
}
