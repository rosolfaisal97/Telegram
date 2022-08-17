using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class AboutUs
    {
        [Key]
        public int id { get; set; }
        public string img { get; set; }
        public string contant { get; set; }
        public int home_id { get; set; }

        [ForeignKey("home_id")]
        public virtual Home Home  { get; set; }
    }
}
