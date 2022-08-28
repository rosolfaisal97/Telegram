using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class RoleService : IRoleService
    {
        

        private readonly IRole RoleRepo;
        public RoleService(IRole RoleRepo)
        {
            this.RoleRepo = RoleRepo;
        }
        public bool DeleteRole(Role roles)
        {
            return RoleRepo.DeleteRole(roles);   
        }

        public List<Role> GetAllRole()
        {
            return RoleRepo.GetAllRole();
        }

        public List<Role> GetRoleNameById(Role role)
        {
            return RoleRepo.GetRoleNameById(role);
        }

        public bool InsertRole(Role roles)
        {
            return RoleRepo.InsertRole(roles);
        }

        public bool UpdateRole(Role roles)
        {
            return RoleRepo.UpdateRole(roles);
        }
    }
}
