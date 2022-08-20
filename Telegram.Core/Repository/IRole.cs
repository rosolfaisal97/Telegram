using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface IRole
    {
       
        public List<Role> GetAllRole();
        public Role InsertRole(Role roles);
        public bool UpdateRole(Role roles);
        public bool DeleteRole(int R_id);
        public List<GetRoleNameByIddto> GetRoleNameById(int R_id);


    }
}