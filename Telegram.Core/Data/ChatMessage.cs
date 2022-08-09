using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class ChatMessage
    {
        [Key]
        public int id { get; set; }
        public int user_from { get; set; }


        [ForeignKey("user_from")]
        public virtual User UserFrom { get; set; }
        public int user_to { get; set; }


        [ForeignKey("user_to")]
        public virtual User UserTo { get; set; }
        public string content { get; set; }
        public int is_read { get; set; }
        public DateTime created_at { get; set; }
        public ICollection<MediaMessage> media_message { get; set; }

    }
}
