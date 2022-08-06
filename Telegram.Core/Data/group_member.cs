using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class group_member
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        
        [ForeignKey("group_id")]
        public virtual groups groups { get; set; }
    }
}
