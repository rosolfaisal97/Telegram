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

        [ForeignKey("login_id ")]
        public virtual Login  Login { get; set; }

        public ICollection<user_block_list> block_lists { get; set; }

        public ICollection<report_user> report_users { get; set; }

        public ICollection<friends>  friends { get; set; }

        public ICollection<chat_message> chat_message { get; set; }

        public ICollection<groups> groups { get; set; }
        public ICollection<group_member> group_member { get; set; }
        public ICollection<group_admin> group_admin { get; set; }
        public ICollection<group_message> group_message { get; set; }
        public ICollection<channel> channel { get; set; }
        public ICollection<post> posts { get; set; }
        public ICollection<comments> comments { get; set; }
        public ICollection<reaction> reaction { get; set; }
        public ICollection<report_channel> report_channels { get; set; }
        public ICollection<story> storys { get; set; }
        public ICollection<report_post> report_post { get; set; }

    }
}
