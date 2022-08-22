using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class userBlockListService : IuserBlockListService
    {
        private readonly IUserBlockList UserBlockRepo;
        public userBlockListService(IUserBlockList UserBlockRepo)
        {
            this.UserBlockRepo = UserBlockRepo;
        }
        public bool DeleteUserBlock(UserBlockList userBlock)
        {
            return UserBlockRepo.DeleteUserBlock(userBlock);
        }

        public List<UserBlockList> GetAllUserBlock()
        {
            return UserBlockRepo.GetAllUserBlock();
        }

        public UserBlockList InsertUserBlock(UserBlockList userBlock)
        {
            return UserBlockRepo.InsertUserBlock(userBlock);
        }

        public List<My_block_ListDTO> My_block_List(UserBlockList userBlock)
        {
            return UserBlockRepo.My_block_List(userBlock);
        }

        public bool UpdateUserBlock(UserBlockList userBlock)
        {
            return UserBlockRepo.UpdateUserBlock(userBlock);
        }
    }
}
