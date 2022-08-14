using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
   public interface ILoginService
    {
        public List<Login> GetAllLogin();
        public Login InsertLogin(Login logins);
        public bool UpdateLogin(Login logins);
        public bool DeleteLogin(int L_id);
        public string Authentication_jwt(AuthLoginREPO login);
        public bool RePasswordUser(RePasswordUserrEPO rep);
    }
}
