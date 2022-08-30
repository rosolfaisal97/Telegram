using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class ServicesService : IServicesService
    {
        private readonly ISERVICESRepository iSERVICESRepository ;

        public ServicesService(ISERVICESRepository iSERVICESRepository)
        {
            this.iSERVICESRepository = iSERVICESRepository;
        }

        public bool CreateSERVICES(Services services)
        {
            return iSERVICESRepository.CreateSERVICES(services);
        }

        public bool DeleteSERVICES(int id)
        {
            return iSERVICESRepository.DeleteSERVICES(id);
        }

        public List<Services> GetAllSERVICES()
        {
            return iSERVICESRepository.GetAllSERVICES();
        }

        public bool UpdateSERVICES(Services services)
        {
            return iSERVICESRepository.UpdateSERVICES(services);
        }
    }
}
