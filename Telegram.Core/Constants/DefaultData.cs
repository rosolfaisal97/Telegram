using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Core.Data;
using Telegram.Core.Repository;

namespace Telegram.Core.Constants
{
    public static class DefaultData
    {
        public static void SeedAsync(IRole roleRepo, Iusers userRepo, ILogin loginRepo)
        {
            //add default roles
            if (!roleRepo.GetAllRole().Any())
            {
                roleRepo.InsertRole(new Role { name = "Admin" });
                roleRepo.InsertRole(new Role { name = "User" });
            }

            //add default user(admin)

            var loginDB = loginRepo.GetAllLogin()
                .Where(l => l.username == "admin").FirstOrDefault();

            if (loginDB == null)
            {
                Login login = new Login
                {
                    username = "admin",
                    email = "admin@gmail.com",
                    password = "123456",
                    role_id = roleRepo.GetAllRole().Where(r => r.name == "Admin").FirstOrDefault().id
                };
                loginRepo.InsertLogin(login);
                User user = new User
                {
                    first_name = "admin",
                    middle_name = "admin",
                    last_name = "admin",
                    gender = "M",
                    login_id = loginRepo
                                 .GetAllLogin()
                                 .Where(l => l.username == "admin")
                                 .FirstOrDefault().id
                };
                userRepo.InsertUsers(user);
            }





        }

    }
}
