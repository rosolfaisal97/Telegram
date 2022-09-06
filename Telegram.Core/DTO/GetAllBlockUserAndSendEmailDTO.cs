using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class GetAllBlockUserAndSendEmailDTO
    {
        public int Id {get;set;}
        public string NameUser { get;set;}
        public string LastName { get;set;}

        public string imagepath { get; set; }

        public string email { get; set; }

        public int SendEmail { get; set; }

    }
}
