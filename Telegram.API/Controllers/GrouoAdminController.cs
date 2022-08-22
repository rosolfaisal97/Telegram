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
    [Route("api/[controller]/[action]")]
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
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<GroupAdmin>), StatusCodes.Status200OK)]
        public List<GroupAdmin> GetAllAdminGroup()
        {
            return grouoAdminService.GetAllAdminGroup();
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(GroupAdmin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool createadmingroup([FromBody] GroupAdmin groupAdmin)
        {
            return grouoAdminService.CreateAdminGroup(groupAdmin);
        }



        [HttpDelete("delete")]
        [Authorize(Roles = "User,Admin")]
        public bool DeleteAdminGroup([FromBody] GroupAdmin groupAdmin)
        {
            return grouoAdminService.DeleteAdminGroup(groupAdmin);
        }



        [HttpPut]
        [Authorize(Roles = "User")]
        public bool UpdateAdminGroup([FromBody] GroupAdmin groupAdmin)
        {
            return grouoAdminService.UpdateAdminGroup(groupAdmin);
        }


    }
}
