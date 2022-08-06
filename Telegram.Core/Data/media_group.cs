using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class media_group
    {
        [Key]
        public int id { get; set; }
        public string file_path { get; set; }
        public string caption { get; set; }

        [ForeignKey("group_message_id ")]
        public virtual group_message Group_Message { get; set; }
    }
}
