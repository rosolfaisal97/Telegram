using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class TestamonialUserDto
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string image_path { get; set; }
        public string description { get; set; }
        public int is_accept { get; set; }
    }
}
