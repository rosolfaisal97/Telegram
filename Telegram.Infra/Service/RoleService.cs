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
        public bool DeleteRole(int R_id)
        {
            return RoleRepo.DeleteRole(R_id);   
        }

        public List<Role> GetAllRole()
        {
            return RoleRepo.GetAllRole();
        }

        public List<GetRoleNameByIddto> GetRoleNameById(int R_id)
        {
            return RoleRepo.GetRoleNameById(R_id);
        }

        public Role InsertRole(Role roles)
        {
            return RoleRepo.InsertRole(roles);
        }

        public bool UpdateRole(Role roles)
        {
            return RoleRepo.UpdateRole(roles);
        }
    }
}
