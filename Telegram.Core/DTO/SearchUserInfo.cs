using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class SearchUserInfo
    {
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string gender { get; set; }
        public string Images { get; set; }

        public DateTime Created_Date { get; set; }

    }
}
