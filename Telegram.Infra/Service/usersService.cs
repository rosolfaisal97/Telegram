using System;
using System.Collections.Generic;
using System.Linq;
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


        public List<AdminBlockDto> AdminBlock(int id)
        {
            return UserRepo.AdminBlock(id);
        }

        public List<User> CheckStatusBlock(int id)
        {
            return UserRepo.CheckStatusBlock(id);
        }

        public bool DeleteUsers(User user)

        {
            return UserRepo.DeleteUsers(user);
        }

        public List<User> GetAllUsers()
        {
            return UserRepo.GetAllUsers();
        }

        public List<AdminBlockDto> GetAllUsersBlocked()
        {
            return UserRepo.GetAllUsersBlocked();
        }

        public User InsertUsers(User user)
        {
            return UserRepo.InsertUsers(user);
        }

        public List<NumberOfUserdto> NumberOfUser()
        {
            return UserRepo.NumberOfUser();
        }

        public List<NumberOfUserByGenderdto> NumberOfUserByGender(User user)
        {
            return UserRepo.NumberOfUserByGender(user);
        }


        public InsertUsersRepo RegisterUser(InsertUsersRepo InsertUser)
        {
            return UserRepo.RegisterUser(InsertUser);
        }

        public List<SearchUserInfo> SarchUserInfo(string sarch)
        {
            return UserRepo.SarchUserInfo(sarch);
        }

        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(DateTime dateto, DateTime datefrom)
        {
            return UserRepo.SearchButweenTwoDate(dateto, datefrom);
        }

        public bool UpdateProfileUser(UpdateProfileUserDTO UpdateUser)
        {
            return UserRepo.UpdateProfileUser(UpdateUser);
        }

        public bool UpdateUsers(User user)
        {
            return UserRepo.UpdateUsers(user);
        }
        public GetUserByIdDto GetUserById(int U_id)
        {
            return UserRepo.GetUserById(U_id);
        }
        public bool EmailSenduserblock(int id)
        {
            return UserRepo.EmailSenduserblock(id);
        }

        public bool sendstoreEmail(int id)
        {
            return UserRepo.sendstoreEmail(id);
        }
 
        public List<UserActiveDto> GetAllUsersActive()
        {
            return UserRepo.GetAllUsersActive();

        }


        public List<SearchUserDto> SearchUser(SearchUserDto filter)
        {
            return UserRepo.SearchUser(filter);
        }
        public List<UserActiveDto> GetAllUsersActive()
         {
                return UserRepo.GetAllUsersActive();
            }

         public List<UserNotActiveDto> GetAllUsersNotActive()
            {
                return UserRepo.GetAllUsersNotActive();
            }



        }

           }

