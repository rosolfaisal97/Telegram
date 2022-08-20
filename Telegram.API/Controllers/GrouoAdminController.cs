using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GrouoAdminController : Controller
    {
        private readonly IGrouoAdminService grouoAdminService;
        public GrouoAdminController(IGrouoAdminService _grouoAdminService)
        {
            grouoAdminService = _grouoAdminService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GroupAdmin>), StatusCodes.Status200OK)]
        public List<GroupAdmin> GetAllAdminGroup()
        {
            return grouoAdminService.GetAllAdminGroup();
        }


        [HttpPost]
        [ProducesResponseType(typeof(GroupAdmin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool createadmingroup([FromBody] GroupAdmin groupAdmin)
        {
            return grouoAdminService.CreateAdminGroup(groupAdmin);
        }



        [HttpDelete("delete/{id}")]
        public bool DeleteAdminGroup(int id)
        {
            return grouoAdminService.DeleteAdminGroup(id);
        }



        [HttpPut]
        public bool UpdateAdminGroup([FromBody] GroupAdmin groupAdmin)
        {
            return grouoAdminService.UpdateAdminGroup(groupAdmin);
        }


    }
}
