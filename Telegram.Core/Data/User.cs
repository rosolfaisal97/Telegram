using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class User
    {
        [Key]

        public int id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string bio { get; set; }
        public string gender { get; set; }

        public string image_path { get; set; }

        public DateTime created_at { get; set; }
        public int login_id { get; set; }

        public int is_blocked { get; set; }


        [ForeignKey("login_id")]
        public virtual Login  Login { get; set; }

        public ICollection<UserBlockList> block_lists { get; set; }

        public ICollection<ReportUser> report_users { get; set; }

        public ICollection<Friends>  friends { get; set; }

        public ICollection<ChatMessage> chat_message { get; set; }

        public ICollection<Groups> groups { get; set; }
        public ICollection<GroupMember> group_member { get; set; }
        public ICollection<GroupAdmin> group_admin { get; set; }
        public ICollection<GroupMessage> group_message { get; set; }
        public ICollection<Channel> channel { get; set; }
        public ICollection<Post> posts { get; set; }
        public ICollection<Comments> comments { get; set; }
        public ICollection<Reaction> reaction { get; set; }
        public ICollection<ReportChannel> report_channels { get; set; }
        public ICollection<Story> storys { get; set; }
        public ICollection<ReportPost> report_post { get; set; }

    }
}
