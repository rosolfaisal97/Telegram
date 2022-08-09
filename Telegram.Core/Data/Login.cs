using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class Login
    {

        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public virtual Role role  { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
