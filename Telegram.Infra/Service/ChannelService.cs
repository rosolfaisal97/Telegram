using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository channelRepository;

        public ChannelService(IChannelRepository channelRepository)
        {
            this.channelRepository = channelRepository;
        }

        public bool CreateChannel(Channel channel)
        {
            return channelRepository.CreateChannel(channel);
        }

        public bool DeleteChannel(int id)
        {
           return channelRepository.DeleteChannel(id);
        }

        public List<Channel> GetAllChannel()
        {
            return channelRepository.GetAllChannel();
        }

        public bool UpdateChannel(Channel channel)
        {
           return channelRepository.UpdateChannel(channel);
        }
    }
}
