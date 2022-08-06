using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class user_block_list
    { 
        [Key]
        public int id { get; set; }

        [ForeignKey("user_from")]
        public virtual User UserFrom  { get; set; }

        [ForeignKey("user_to")]
        public virtual User UserTo { get; set; }
    }
}
