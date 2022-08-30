using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class EmailSendDTO
    {
        public string NameUserto { get; set; }
        public string LastNameto { get; set; }
        public string email { get; set; }
        public string NameUserfrom { get; set; }
        public string LastNamefrom { get; set; }
    }
}
