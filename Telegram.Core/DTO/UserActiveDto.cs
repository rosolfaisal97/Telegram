using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class UserActiveDto
    {
        public int ConnectionId { get; set; }
        public int UserId { get; set; }
       
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string imagePath { get; set; }

    }
}
