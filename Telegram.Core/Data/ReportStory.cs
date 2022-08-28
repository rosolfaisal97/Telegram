using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Telegram.Core.Data
{
    public class ReportStory
    {

        [Key]
        public int Id { get; set; }
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        public int story_id { get; set; }


        [ForeignKey("story_id")]
        public virtual Story Story { get; set; }
        public string Type { get; set; }
        public string description { get; set; }

        public int is_accept { get; set; }
    }
}
