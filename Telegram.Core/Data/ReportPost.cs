using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class ReportPost
    {

        [Key]
        public int id { get; set; }
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        public int post_id { get; set; }


        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }
        public string type { get; set; }
        public string description { get; set; }

        public int is_accept { get; set; }
    }
}
