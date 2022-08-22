using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    { 
        private readonly IRoleService RoleService;
        public RoleController(IRoleService RoleService)
        {
            this.RoleService = RoleService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool DeleteRole(int id)
        {
            return RoleService.DeleteRole(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        public List<Role> GetAllRole()
        {
            return RoleService.GetAllRole();
        }

        [HttpGet("RoleId")]

        public List<GetRoleNameByIddto> GetRoleNameById(int id)
        {
            return RoleService.GetRoleNameById(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Role InsertRole([FromBody] Role roles)
        {
            return RoleService.InsertRole(roles);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateRole([FromBody] Role roles)
        {
            return RoleService.UpdateRole(roles);
        }
    }
}
