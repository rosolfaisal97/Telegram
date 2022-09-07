using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface IConnectionRepository
    {
        bool Insert(Connection connection);
        bool update(Connection connection);
        bool delete(Connection connection);
        ConnectionDTO GetItem(Connection connection);
        List<ConnectionDTO> GetAll();
        int GetAllCount();


    }
}
