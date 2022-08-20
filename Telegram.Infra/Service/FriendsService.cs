using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Constants;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;
using Telegram.Infra.Repository;

namespace Telegram.Infra.Service
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendsRepository _friendsRepository;

        public FriendsService(IFriendsRepository friendsRepository)
        {
            _friendsRepository = friendsRepository;
        }

        public bool AcceptFriendRequest(int userFrom, int userTo)
        {
            if (_friendsRepository.HasFriendship(userFrom, userTo))
                if (_friendsRepository.GetFriendship(userFrom, userTo)
                   .Status == (int)FriendshipStatus.Pending)
                    return _friendsRepository.AcceptFriendRequest(userFrom, userTo);

            return false;
        }

        public bool DeleteFriendRequest(int userFrom, int userTo)
        {
            if (_friendsRepository.HasFriendship(userFrom, userTo))
                if (_friendsRepository.GetFriendship(userFrom, userTo)
                   .Status == (int)FriendshipStatus.Pending)
                    return _friendsRepository.DeleteFriendRequest(userFrom, userTo);

            return false;
        }

        public bool DeleteFriendship(int userFrom, int userTo)
        {
            if (_friendsRepository.HasFriendship(userFrom, userTo))
                if (_friendsRepository.GetFriendship(userFrom, userTo)
                   .Status == (int)FriendshipStatus.Accepted)
                    return _friendsRepository.DeleteFriendship(userFrom, userTo);

            return false;

        }

        public FriendshipStatusDTO GetFriendship(int userFrom, int userTo)
        {
            var result = _friendsRepository.GetFriendship(userFrom, userTo);
            if (result == null) return new FriendshipStatusDTO { Status=-1};

            return result;
        }

        public List<User> GetFriendshipRequests(int userFrom)
        {
            return _friendsRepository.GetFriendshipRequests(userFrom);
        }

        public List<User> GetUserFriends(int userFrom)
        {
            return _friendsRepository.GetUserFriends(userFrom);
        }

        public bool HasFriendship(int userFrom, int userTo)
        {
            return _friendsRepository.HasFriendship(userFrom, userTo);
        }

        public bool HeSent(int userFrom, int userTo)
        {
            return _friendsRepository.HeSent(userFrom, userTo);
        }

        public bool InsertFriendRequest(int userFrom, int userTo)
        {
            if (_friendsRepository.HasFriendship(userFrom, userTo))
                if (_friendsRepository.GetFriendship(userFrom, userTo)
                    .Status == (int)FriendshipStatus.Rejected)
                    return ReSentFriendRequest(userFrom, userTo);
                else return false;

            return _friendsRepository.InsertFriendRequest(userFrom, userTo);
        }

        public bool ReSentFriendRequest(int userFrom, int userTo)
        {
            return _friendsRepository.ReSentFriendRequest(userFrom, userTo);
        }
    }
}
