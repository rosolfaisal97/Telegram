using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IChannelService
    {
        bool CreateChannel(Channel channel);
        List<Channel> GetAllChannel();
        bool UpdateChannel(Channel channel);
        bool DeleteChannel(Channel channel);
    }
}
