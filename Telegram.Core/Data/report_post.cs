using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class report_post
    {

        [Key]
        public int id { get; set; }
        [ForeignKey("user_id")]
        public virtual User user { get; set; }

        [ForeignKey("post_id")]
        public virtual post Post { get; set; }
        public string type { get; set; }
        public string description { get; set; }

        public int is_accept { get; set; }
    }
}
