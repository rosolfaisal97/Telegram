using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class FilterChannelByMember
    {
        public int CHid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }

    }
}
