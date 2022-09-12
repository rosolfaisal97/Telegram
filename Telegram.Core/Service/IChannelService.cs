using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IChannelService
    {
        bool CreateChannel(Channel channel);
        List<Channel> GetAllChannel();
        bool UpdateChannel(Channel channel);
        bool DeleteChannel(Channel channel);

        bool CreatePost(Creatpost creatpost);


        public List<SearchChannelDto> SearchChannel(SearchChannelDto filter);
    }
}
