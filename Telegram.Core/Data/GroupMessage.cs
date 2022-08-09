using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class GroupMessage
    {
        [Key]
        public int id { get; set; }
        public int from_id { get; set; }

        [ForeignKey("from_id")]
        public virtual User user { get; set; }
        public int group_id { get; set; }


        [ForeignKey("group_id")]
        public virtual Groups groups { get; set; }
        public string content { get; set; }
        public DateTime created_at { get; set; }

        public ICollection<MediaGroup> media_group { get; set; }

    }
}
