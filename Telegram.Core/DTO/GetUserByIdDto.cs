using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class GetUserByIdDto
    {
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }

        public string Images { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


    }
}
