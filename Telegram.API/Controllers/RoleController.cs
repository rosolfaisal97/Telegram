using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("(api/[controller]/[action]")]
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
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool DeleteRole([FromBody] Role roles)
        {
            return RoleService.DeleteRole(roles);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        public List<Role> GetAllRole()
        {
            return RoleService.GetAllRole();
        }

 
        [HttpGet("RoleId/{R_id}")]
        [Authorize(Roles = "Admin")]
        public List<GetRoleNameByIddto> GetRoleNameById(int R_id)
         {
            return RoleService.GetRoleNameById(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Role InsertRole([FromBody] Role roles)
        {
            return RoleService.InsertRole(roles);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateRole([FromBody] Role roles)
        {
            return RoleService.UpdateRole(roles);
        }
    }
}
