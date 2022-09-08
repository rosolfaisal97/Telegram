using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface IFriendsRepository
    {
        bool InsertFriendRequest(UserFormDTO user);
        bool DeleteFriendRequest(UserFormDTO user);
        bool AcceptFriendRequest(UserFormDTO user);
        bool DeleteFriendship(UserFormDTO user);
        bool HasFriendship(UserFormDTO user);
        bool HeSent(UserFormDTO user);

        List<User> GetUserFriends(UserFormDTO user);
        FriendshipStatusDTO GetFriendship(UserFormDTO user);

        List<User> GetFriendshipRequests(UserFormDTO user);
        bool ReSentFriendRequest(UserFormDTO user);

        
    }
}
