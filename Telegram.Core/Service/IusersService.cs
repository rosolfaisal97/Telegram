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
        public User InsertUsers(User uss);
        public bool UpdateUsers(User uss);
        public bool DeleteUsers(int? U_id);
        public InsertUsersRepo RegisterUser(InsertUsersRepo Ins);
        public bool UpdateProfileUser(UpdateProfileUserDTO Upd);

        public List<NumberOfUserdto> NumberOfUser();
        public List<NumberOfUserByGenderdto> NumberOfUserByGender(NumberOfUserByGenderdto numberusergender);
        public List<SearchUserInfo> SarchUserInfo(SearchUserInfo searchUser);
        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(SearchButweenTwoDatedto c);
    }
}
