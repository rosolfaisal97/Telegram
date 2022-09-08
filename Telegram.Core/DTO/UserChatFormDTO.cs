using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class UserChatFormDTO
    {
        public int Id { get; set; }
        public string message { get; set; }
        public int IsRead { get; set; }
        public DateTime Datetime { get; set; }

        public int UserFromId { get; set; }
        public int UserToId { get; set; }
    }
}
