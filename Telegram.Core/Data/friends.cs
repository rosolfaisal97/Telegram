using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class Friends
    {
        [Key]
        public int id { get; set; }
        
        [ForeignKey("From")]
        public int UserFrom { get; set; }
        [ForeignKey("To")]
        public int UserTo { get; set; }
        
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User From { get; set; }
        public virtual User To { get; set; }



    }
}
