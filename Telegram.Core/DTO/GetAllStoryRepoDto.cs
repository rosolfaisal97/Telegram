using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class GetAllStoryRepoDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public int IsAccept { get; set; }
    }
}
