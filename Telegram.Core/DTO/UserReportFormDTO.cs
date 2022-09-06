using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class UserReportFormDTO
    {
        public int Id { get; set; }
        public int UserFromId { get; set; }
        public int UserToId { get; set; }
        public string Type { get; set; }
        public int IsAccept { get; set; }
        public string Description { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
