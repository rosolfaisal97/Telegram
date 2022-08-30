using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IServicesService
    {
        bool CreateSERVICES(Services services);
        List<Services> GetAllSERVICES();
        bool UpdateSERVICES(Services services);
        bool DeleteSERVICES(int id);
    }
}
