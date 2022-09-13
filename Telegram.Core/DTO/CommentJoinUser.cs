using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class CommentJoinUser
    {
        public int Comment_ID { get; set; }
        public int userId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string UserImage { get; set; }
        public int postId { get; set; }
        public string content { get; set; }
        public string createdAt { get; set; }
    }
}
