using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class group_message
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("from_id")]
        public virtual User user { get; set; }

        [ForeignKey("group_id")]
        public virtual groups groups { get; set; }
        public string content { get; set; }
        public DateTime created_at { get; set; }

        public ICollection<media_group> media_group { get; set; }

    }
}
