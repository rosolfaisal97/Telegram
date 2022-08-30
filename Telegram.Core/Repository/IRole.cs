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
        public bool InsertRole(Role roles);
        public bool UpdateRole(Role roles);
        public bool DeleteRole(Role roles);
        public List<Role> GetRoleNameById(Role role);


    }
}