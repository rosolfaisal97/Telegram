using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class Groups
    {
        [Key]

        public int Id { get; set; } 
        public string name { get; set; }
        public int owner_id { get; set; }

        [ForeignKey("owner_id")]
        public virtual User Owner { get; set; }

        public string bio { get; set; }
        public string image_path { get; set; }

        public string group_id { get; set; }

        public ICollection<GroupLink> group_link { get; set; }
        public ICollection<GroupMember> group_member { get; set; }
        public ICollection<GroupAdmin> group_admin { get; set; }
        public ICollection<GroupMessage> group_message { get; set; }


    }
}
