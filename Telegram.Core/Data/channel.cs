using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class Channel
    {

        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public int owner_id { get; set; }


        [ForeignKey("owner_id")]
        public virtual User owner { get; set; }
        public string bio { get; set; }
        public int is_private { get; set; }
        public string Image_path { get; set; }
        public ICollection<ChannelMember> channel_member { get; set; }
        public ICollection<ChannelAdmin> channel_admins { get; set; }
        public ICollection<Post> posts { get; set; }
        public ICollection<ReportChannel> report_channels { get; set; }


    }
}
