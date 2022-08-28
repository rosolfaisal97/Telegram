using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class RePasswordDTO
    {
        public int loginId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
