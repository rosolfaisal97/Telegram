using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.DTO
{
    public class ConnectionDTO
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
    }
}
