using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface ICount
    {
        public List<NumberOfGroups> NumberOfGroups();
        public List<NumberOfChannels> NumberOfChannels();
        public List<NumberOfUsers> NumberOfUsers();
    }
}
