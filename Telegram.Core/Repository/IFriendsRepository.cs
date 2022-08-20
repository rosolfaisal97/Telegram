using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface IFriendsRepository
    {
        bool InsertFriendRequest(int userFrom, int userTo);
        bool DeleteFriendRequest(int userFrom, int userTo);
        bool AcceptFriendRequest(int userFrom, int userTo);
        bool DeleteFriendship(int userFrom, int userTo);
        bool HasFriendship(int userFrom, int userTo);
        bool HeSent(int userFrom, int userTo);

        List<User> GetUserFriends(int userFrom);
        FriendshipStatusDTO GetFriendship(int userFrom,int userTo);

        List<User> GetFriendshipRequests(int userFrom);
        bool ReSentFriendRequest(int userFrom, int userTo);


    }
}
