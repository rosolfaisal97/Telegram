using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class ReactionDetailsDTO
    {
        public int id { get; set; }
      
        public int isReact { get; set; }
        public int PostId { get; set; }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int LoginId { get; set; }
        public string ImagePath { get; set; }
    }
}
