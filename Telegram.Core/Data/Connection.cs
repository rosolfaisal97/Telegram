using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.Data
{
    public class Connection
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
