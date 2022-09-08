using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class MemberChannel
    {
        public int ChannelId { get; set; }
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string imagePath { get; set; }
    }
}
