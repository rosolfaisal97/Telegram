using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class Testimonial
    {
        [Key]
        public int id { get; set; }
        public int user_from { get; set; }
        public string description { get; set; }
        public int is_accept { get; set; }

        [ForeignKey("user_from")]
        public virtual  User Users { get; set; }

    }
}
