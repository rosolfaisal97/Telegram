using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class media_post
    {
        [Key]
        public int id { get; set; }
        public string file_path { get; set; }
        [ForeignKey("post_id")]
        public virtual post post { get; set; }
    }
}
