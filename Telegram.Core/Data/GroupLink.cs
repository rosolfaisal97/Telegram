using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class GroupLink
    {

        [Key]
        public int id { get; set; }
        public string link { get; set; }

        public DateTime period_time { get; set; }
        public int group_id { get; set; }


        [ForeignKey("group_id")]
        public virtual Groups groups { get; set; }
        public DateTime created_at { get; set; }
    }
}
