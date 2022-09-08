using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class CommentFormDTO
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
    }
}
