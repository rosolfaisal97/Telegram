using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IusersService
    {
        public List<User> GetAllUsers();
        public User InsertUsers(User user);
        public bool UpdateUsers(User user);
        public bool DeleteUsers(User user);

        public InsertUsersRepo RegisterUser(InsertUsersRepo InsertUser);
        public bool UpdateProfileUser(UpdateProfileUserDTO UpdateUser);

        public List<NumberOfUserdto> NumberOfUser();
        public List<NumberOfUserByGenderdto> NumberOfUserByGender(User user);

        public List<SearchUserInfo> SarchUserInfo(string sarch);
        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(DateTime dateto, DateTime datefrom);
    }
}
