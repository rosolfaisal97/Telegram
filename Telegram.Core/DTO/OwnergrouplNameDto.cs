using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class OwnergrouplNameDto
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string imagePath { get; set; }
    }
}
