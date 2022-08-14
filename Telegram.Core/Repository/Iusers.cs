﻿using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface Iusers
    {
        public List<User> GetAllUsers();
        public User InsertUsers(User uss);
        public bool UpdateUsers(User uss);
        public bool DeleteUsers(int U_id);
        public InsertUsersRepo RegisterUser(InsertUsersRepo Ins);
        public bool UpdateProfileUser(UpdateProfileUserDTO Upd);

        public List<NumberOfUserdto> NumberOfUser();
        public List<NumberOfUserByGenderdto> NumberOfUserByGender(string U_gender);
        public List<SearchUserInfo> SarchUserInfo( string sarch);
        public List<SearchButweenTwoDatedto> SearchButweenTwoDate( DateTime dateto ,DateTime datefrom );
    }
}
