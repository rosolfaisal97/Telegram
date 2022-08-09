﻿using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Repository
{
    public interface IChannelMemberRepository
    {
        bool CreateChannelMember(ChannelMember channel_Member );
        List<ChannelMember> GetAllChannelMember();
        bool UpdateChannelMember(ChannelMember channel_Member );
        bool DeleteChannelMember(int id);

    }
}
