using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class SearchUserDto
    {
        public string nameUser { get; set; }
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }
}
