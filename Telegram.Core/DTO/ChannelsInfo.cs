using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class ChannelsInfo
    {
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bio { get; set; }
        public int is_private { get; set; }
    }
}
