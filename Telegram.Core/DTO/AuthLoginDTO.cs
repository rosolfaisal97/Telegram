using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Core.DTO
{
    public class AuthLoginDTO
    {
        public int LoginId { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
