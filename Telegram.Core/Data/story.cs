using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class story
    {

        [Key]
        public int id { get; set; }

        public string content { get; set; }
        public string file_path { get; set; }

        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        public DateTime created_at { get; set; }
    }
}
