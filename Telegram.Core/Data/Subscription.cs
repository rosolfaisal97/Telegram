using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public  class Subscription
    {

        [Key]
        public int id { get; set; }

        public int servicesId { get; set; } 
        
        [ForeignKey("servicesId")]
      
        public virtual Services Service  { get; set; }
       
        public int userId { get; set; }
        
        [ForeignKey("userId ")]
        public virtual User User { get; set; }

        public string Status { get; set; }
        public DateTime? Createtime { get; set; }

       

    }
}
