using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class post
    {

        [Key]
        public int id { get; set; }
        [ForeignKey("admin_id ")]
        public virtual User user { get; set; }

        [ForeignKey("channel_id")]
        public virtual channel Channel { get; set; }
        public string content { get; set; }
        public int post_id { get; set; }
        public DateTime created_at { get; set; }

        public ICollection<media_post> media_posts { get; set; }
        public ICollection<comments> comments { get; set; }
        public ICollection<reaction> reaction { get; set; }
        public ICollection<report_post> report_post { get; set; }

    }
}
