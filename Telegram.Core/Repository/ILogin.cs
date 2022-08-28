using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface ILogin
    {
        public List<Login> GetAllLogin();
        public Login InsertLogin(Login login);
        public bool UpdateLogin(Login login);
        public bool DeleteLogin(Login login);
        public AuthLoginDTO AuthLogin(AuthLoginDTO login);
        public  bool RePasswordUser(RePasswordDTO rePasswordDTO);
        public bool ChackPassword(RePasswordDTO rePasswordDTO);

    }


}
