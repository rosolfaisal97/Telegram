using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IRoleService
    {
        public List<Role> GetAllRole();
        public Role InsertRole(Role roles);
        public bool UpdateRole(Role roles);
        public bool DeleteRole(int? R_id);
        public Role GetRoleNameById(int R_id);

    }
}
