using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Telegram.Core.Data
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<Login> Logins { get; set; }
    }
}
