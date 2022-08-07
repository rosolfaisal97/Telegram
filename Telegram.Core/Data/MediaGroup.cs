using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class MediaGroup
    {
        [Key]
        public int id { get; set; }
        public string file_path { get; set; }
        public string caption { get; set; }
        public int group_message_id { get; set; }


        [ForeignKey("group_message_id")]
        public virtual GroupMessage Group_Message { get; set; }
    }
}
