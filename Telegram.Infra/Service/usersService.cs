using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class usersService : IusersService
    {

        private readonly Iusers UserRepo;
        public usersService(Iusers UserRepo)
        {
            this.UserRepo = UserRepo;
        }
        public bool DeleteUsers(int? U_id)
        {
            return UserRepo.DeleteUsers(U_id);
        }

        public List<User> GetAllUsers()
        {
            return UserRepo.GetAllUsers();
        }

        public User InsertUsers(User uss)
        {
            return UserRepo.InsertUsers(uss);
        }

        public List<NumberOfUserdto> NumberOfUser()
        {
            return UserRepo.NumberOfUser();
        }

        public List<NumberOfUserByGenderdto> NumberOfUserByGender(NumberOfUserByGenderdto numberusergender)
        {
            return UserRepo.NumberOfUserByGender(numberusergender);
        }

        public InsertUsersRepo RegisterUser(InsertUsersRepo Ins)
        {
            return UserRepo.RegisterUser(Ins);
        }

        public List<SearchUserInfo> SarchUserInfo(SearchUserInfo searchUser)
        {
            return UserRepo.SarchUserInfo(searchUser);
        }

        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(SearchButweenTwoDatedto c)
        {
            return UserRepo.SearchButweenTwoDate(c);
        }

        public bool UpdateProfileUser(UpdateProfileUserDTO Upd)
        {
            return UserRepo.UpdateProfileUser(Upd);
        }

        public bool UpdateUsers(User uss)
        {
            return UserRepo.UpdateUsers(uss);
        }
    }
}
