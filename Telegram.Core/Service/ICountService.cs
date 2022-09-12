using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface ICountService
    {
        public List<NumberOfGroups> NumberOfGroups();
        public List<NumberOfChannels> NumberOfChannels();
        public List<NumberOfUsers> NumberOfUsers();
    }
}
