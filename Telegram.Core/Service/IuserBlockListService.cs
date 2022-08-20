using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IuserBlockListService
    {
        public List<UserBlockList> GetAllUserBlock();
        public UserBlockList InsertUserBlock(UserBlockList userBlock);
        public bool UpdateUserBlock(UserBlockList userBlock);
        public bool DeleteUserBlock(int UB_id);
        public List<My_block_ListDTO> My_block_List(int user_id);
    }
}
