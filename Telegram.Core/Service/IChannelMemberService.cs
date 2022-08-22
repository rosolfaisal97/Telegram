using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IChannelMemberService
    {
        bool CreateChannelMember(ChannelMember channel_Member);
        List<ChannelMember> GetAllChannelMember();
        bool UpdateChannelMember(ChannelMember channel_Member);
        bool DeleteChannelMember(ChannelMember channel_Member);
    }
}
