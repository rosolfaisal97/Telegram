using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class MediaMessage
    {
        [Key]
        public int id { get; set; }
        public string file_path { get; set; }
        public string caption { get; set; }
        public int message_id { get; set; }


        [ForeignKey("message_id")]
        public virtual ChatMessage chat { get; set; }
    }
}
