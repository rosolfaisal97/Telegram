using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class ChannelProfile
    {
        public int Id { get; set; }
        public string username{ get; set; }
        public string bio { get; set; }
        public int is_private { get; set; }

        public string image_path { get; set; }


    }
}
