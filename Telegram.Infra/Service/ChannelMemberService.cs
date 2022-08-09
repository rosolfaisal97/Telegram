using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class ChannelMemberService : IChannelMemberService
    {
        private readonly IChannelMemberRepository channelMemberRepository;

        public ChannelMemberService(IChannelMemberRepository channelMemberRepository )
        {
            this.channelMemberRepository = channelMemberRepository;
        }

        public bool CreateChannelMember(ChannelMember channel_Member)
        {
            return channelMemberRepository.CreateChannelMember(channel_Member);
        }

        public bool DeleteChannelMember(int id)
        {
           return channelMemberRepository.DeleteChannelMember(id);
        }

        public List<ChannelMember> GetAllChannelMember()
        {
            return channelMemberRepository.GetAllChannelMember();
        }

        public bool UpdateChannelMember(ChannelMember channel_Member)
        {
           return channelMemberRepository.UpdateChannelMember(channel_Member);
        }
    }
}
