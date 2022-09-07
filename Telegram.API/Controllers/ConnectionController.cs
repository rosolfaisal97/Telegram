using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ConnectionController : Controller
    {
        private readonly IConnectionService _connectionService;
        public ConnectionController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        [HttpPost]
        public bool delete([FromBody] Connection connection)
        {
            return _connectionService.delete(connection);
        }

        [HttpGet]
        public List<ConnectionDTO> GetAll()
        {
            return _connectionService.GetAll();
        }
        [HttpGet]
        public int GetAllCount()
        {
            return _connectionService.GetAllCount();
        }

        [HttpGet]
        [Route("{userId}")]
        public ConnectionDTO GetItemByUser(int userId)
        {
            var data = new Connection
            { 
                UserId = userId
            };
            return _connectionService.GetItem(data);
        }
        [HttpGet]
        [Route("{connId}")]
        public ConnectionDTO GetItemByConn(string connId)
        {
            var data = new Connection
            {
                ConnectionId = connId
            };
            return _connectionService.GetItem(data);
        }

        [HttpPost]
        public bool Insert([FromBody] Connection connection)
        {
            return _connectionService.Insert(connection);
        }
        [HttpPost]
        public bool update([FromBody] Connection connection)
        {
            return _connectionService.update(connection);
        }
    }
}
