using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
     public  class ReportPostJoinDto
    {


        public int postID { get; set; }
        public int fromUser { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string postContent { get; set; }
        public string createAt { get; set; }
        public string filePath { get; set; }
        public int ReportID { get; set; }
        public string repoType { get; set; }
        public string Repodescription { get; set; }
        public int is_accept { get; set; }
      
    }
}
