using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Repository
{
    public interface IChannelAdminRepository
    {
        bool CreateChannelAdmin(ChannelAdmin channel_Admin );
        List<ChannelAdmin> GetAllChannelAdmin();
        bool UpdateChannelAdmin(ChannelAdmin channel_Admin );
        bool DeleteChannelAdmin(int id);

    }
}
