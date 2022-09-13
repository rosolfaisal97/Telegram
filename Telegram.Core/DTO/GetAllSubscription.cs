using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public  class GetAllSubscription
    {

        public int UserId { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string image_path { get; set; }
        public string Status { get; set; }

        public DateTime? Createtime { get; set; }
        
        public string Name { get; set; }
        public int Price { get; set; }

        public string Image { get; set; }

    }
}
