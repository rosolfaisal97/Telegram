using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class GroupMember
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        public int group_id { get; set; }


        [ForeignKey("group_id")]
        public virtual Groups groups { get; set; }
    }
}
