using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class GrouoAdminService : IGrouoAdminService
    {
        private readonly IGrouoAdminRepository grouoAdminRepository; 
        public GrouoAdminService(IGrouoAdminRepository _grouoAdminRepository)
        {
            grouoAdminRepository = _grouoAdminRepository;
        }

        public bool CreateAdminGroup(GroupAdmin groupAdmin)
        {
            return grouoAdminRepository.CreateAdminGroup(groupAdmin);
        }

        public bool DeleteAdminGroup(GroupAdmin groupAdmin)
        {
            return grouoAdminRepository.DeleteAdminGroup(groupAdmin);
        }

        public List<GroupAdmin> GetAllAdminGroup()
        {
            return grouoAdminRepository.GetAllAdminGroup();
        }

        public bool UpdateAdminGroup(GroupAdmin groupAdmin)
        {
            return grouoAdminRepository.UpdateAdminGroup(groupAdmin);
        }
    }
}
