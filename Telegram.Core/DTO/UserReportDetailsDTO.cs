using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class UserReportDetailsDTO
    {
        public int Id { get; set; }
        public string UsernameFrom { get; set; }
        public string UsernameTo { get; set; }
        public string FullNameFrom { get; set; }
        public string FullNameTo { get; set; }
        public int LoginIdTo { get; set; }
        public int LoginIdFrom { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int IsAccept { get; set; }
    }
}
