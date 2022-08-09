using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
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



        [HttpDelete("delete/{R_id}")]
        public bool DeleteRole(int? R_id)
        {
            return RoleService.DeleteRole(R_id);
        }
        [HttpGet]
        public List<Role> GetAllRole()
        {
            return RoleService.GetAllRole();
        }

        [HttpPost("Role/{R_id}")]
       
        public Role GetRoleNameById(int R_id)
        {
            return RoleService.GetRoleNameById(R_id);
        }

        [HttpPost]
        public Role InsertRole([FromBody] Role roles)
        {
            return RoleService.InsertRole(roles);
        }

        [HttpPut]
        public bool UpdateRole([FromBody] Role roles)
        {
            return RoleService.UpdateRole(roles);
        }
    }
}
