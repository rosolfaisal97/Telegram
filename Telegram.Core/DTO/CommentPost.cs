using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class CommentPost
    {
        public string content { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string imagePath { get; set; }
        public DateTime CreateAt { get; set; }


    }
}
