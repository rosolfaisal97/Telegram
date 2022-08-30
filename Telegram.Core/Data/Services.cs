using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Telegram.Core.Data
{
    public class Services
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string descriptions { get; set; }
        public int Price { get; set; }
        public DateTime? Createtime { get; set; }
        public string Image { get; set; }


    }
}
