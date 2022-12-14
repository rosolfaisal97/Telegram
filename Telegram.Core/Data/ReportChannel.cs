using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class ReportChannel
    {

        [Key]
        public int id { get; set; }
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        public int channel_id { get; set; }


        [ForeignKey("channel_id")]
        public virtual Channel Channel { get; set; }
        public string type { get; set; }
        public string description { get; set; }

        public int is_accept { get; set; }
    }
}
