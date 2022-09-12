using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class Top10PostByLike
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string postContent { get; set; }
        public DateTime CreateAt { get; set; }
        public string filePath { get; set; }
        public int CountLike { get; set; }
    }
}
