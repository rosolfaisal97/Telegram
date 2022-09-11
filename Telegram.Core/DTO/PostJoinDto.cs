using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class PostJoinDto
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string postContent { get; set; }
        public string CreateAt { get; set; }
        public string filePath { get; set; }
        public int CountComment { get; set; }
        public int CountLike { get; set; }
        public string ImageUser { get; set; }
        

    }
}
