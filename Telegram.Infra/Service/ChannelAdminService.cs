using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class ChannelAdminService: IChannelAdminService
    {
        private readonly IChannelAdminRepository channelAdminRepository;

        public ChannelAdminService(IChannelAdminRepository channelAdminRepository )
        {
            this.channelAdminRepository = channelAdminRepository;
        }

        public bool CreateChannelAdmin(ChannelAdmin channel_Admin)
        {
            return channelAdminRepository.CreateChannelAdmin(channel_Admin);
        }

        public bool DeleteChannelAdmin(ChannelAdmin channel_Admin)
        {
           return channelAdminRepository.DeleteChannelAdmin(channel_Admin);
        }

        public List<ChannelAdmin> GetAllChannelAdmin()
        {
            return channelAdminRepository.GetAllChannelAdmin();
        }

        public bool UpdateChannelAdmin(ChannelAdmin channel_Admin)
        {
            return channelAdminRepository.UpdateChannelAdmin(channel_Admin);
        }
    }
}
