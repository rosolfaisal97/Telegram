using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class channel_member
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("user_id")]
        public virtual User user { get; set; }

        [ForeignKey("channel_id")]
        public virtual channel Channel  { get; set; }
    }
}
