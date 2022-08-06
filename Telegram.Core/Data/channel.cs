using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class channel
    {

        [Key]
        public int id { get; set; }
        public string username { get; set; }
        
        [ForeignKey("owner_id  ")]
        public virtual User owner { get; set; }
        public string bio { get; set; }
        public int is_private { get; set; }
        public string Image_path { get; set; }
        public ICollection<channel_member> channel_member { get; set; }
        public ICollection<channel_admin> channel_admins { get; set; }
        public ICollection<post> posts { get; set; }
        public ICollection<report_channel> report_channels { get; set; }


    }
}
