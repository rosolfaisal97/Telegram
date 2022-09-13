using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class AllReactionDto
    {
        public int userId { get; set; }
        public int Post_ID { get; set; }
        public int is_React { get; set; }
    }
}
