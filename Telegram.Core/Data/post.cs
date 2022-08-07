using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class Post
    {

        [Key]
        public int id { get; set; }
        public int admin_id { get; set; }

        [ForeignKey("admin_id")]
        public virtual User user { get; set; }
        public int channel_id { get; set; }


        [ForeignKey("channel_id")]
        public virtual Channel Channel { get; set; }
        public string content { get; set; }
        public int post_id { get; set; }
        public DateTime created_at { get; set; }

        public ICollection<MediaPost> media_posts { get; set; }
        public ICollection<Comments> comments { get; set; }
        public ICollection<Reaction> reaction { get; set; }
        public ICollection<ReportPost> report_post { get; set; }

    }
}
