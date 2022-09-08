using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConnectionRepository _connectionRepository;
        public ConnectionService(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }

        public bool delete(Connection connection)
        {
            return _connectionRepository.delete(connection);
        }

        public List<ConnectionDTO> GetAll()
        {
            return _connectionRepository.GetAll();
        }

        public int GetAllCount()
        {
            return _connectionRepository.GetAllCount();
        }

        public ConnectionDTO GetItem(Connection connection)
        {
            return _connectionRepository.GetItem(connection);
        }

        public bool Insert(Connection connection)
        {
            if(GetItem(connection)!=null)
                return _connectionRepository.update(connection);

            return _connectionRepository.Insert(connection);
        }

        public bool update(Connection connection)
        {
            return _connectionRepository.update(connection);
        }
    }
}
