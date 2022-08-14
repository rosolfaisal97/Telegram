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
    public class RoleController : ControllerBase
    { 
        private readonly IRoleService RoleService;
        public RoleController(IRoleService RoleService)
        {
            this.RoleService = RoleService;
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{R_id}")]
        public bool DeleteRole(int R_id)
        {
            return RoleService.DeleteRole(R_id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        public List<Role> GetAllRole()
        {
            return RoleService.GetAllRole();
        }

        [HttpGet("RoleId/{R_id}")]

        public List<GetRoleNameByIddto> GetRoleNameById(int R_id)
        {
            return RoleService.GetRoleNameById(R_id);
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
