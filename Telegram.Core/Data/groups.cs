using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class groups
    {
        [Key]

        public int Id { get; set; } 
        public string name { get; set; }
        
        [ForeignKey("owner_id ")]
        public virtual User Owner { get; set; }

        public string bio { get; set; }
        public string image_path { get; set; }

        public ICollection<group_link> group_link { get; set; }
        public ICollection<group_member> group_member { get; set; }
        public ICollection<group_admin> group_admin { get; set; }
        public ICollection<group_message> group_message { get; set; }


    }
}
