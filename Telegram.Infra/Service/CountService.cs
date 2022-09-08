using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class CountService : ICountService
    {

        private readonly ICount  count;

        public CountService(ICount count)
        {
            this.count = count;
        }
        public List<NumberOfChannels> NumberOfChannels()
        {
            return count.NumberOfChannels();
        }

        public List<NumberOfGroups> NumberOfGroups()
        {
            return count.NumberOfGroups();
        }

        public List<NumberOfUsers> NumberOfUsers()
        {
            return count.NumberOfUsers();
        }
    }
}
