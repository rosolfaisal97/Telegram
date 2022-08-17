using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class ContactUs
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }

        public int home_id { get; set; }

        [ForeignKey("home_id")]
        public virtual Home Home { get; set; }

    }
}
