using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class GetUserSubscription
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public string Image { get; set; }

        public string descriptions { get; set; }
        public string Status { get; set; }

        public DateTime? Createtime { get; set; }

       
    }
}
