using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IGrouoAdminService
    {
        bool CreateAdminGroup(GroupAdmin groupAdmin);
        List<GroupAdmin> GetAllAdminGroup();
        bool UpdateAdminGroup(GroupAdmin groupAdmin);
        bool DeleteAdminGroup(GroupAdmin groupAdmin);
    }
}
