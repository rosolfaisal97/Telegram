using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class Creatpost
    {
        public int admin_id { get; set; }
        public int channel_id { get; set; }
        public string content { get; set; }
        public string file_path { get; set; }

    }
}
