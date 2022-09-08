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

        public bool AcceptFriendRequest(UserFormDTO user)
        {
            if (_friendsRepository.HasFriendship(user))
                if (_friendsRepository.GetFriendship(user)
                   .Status == (int)FriendshipStatus.Pending)
                    return _friendsRepository.AcceptFriendRequest(user);

            return false;
        }

        public bool DeleteFriendRequest(UserFormDTO user)
        {
            if (_friendsRepository.HasFriendship(user))
                if (_friendsRepository.GetFriendship(user)
                   .Status == (int)FriendshipStatus.Pending)
                    return _friendsRepository.DeleteFriendRequest(user);

            return false;
        }

        public bool DeleteFriendship(UserFormDTO user)
        {
            if (_friendsRepository.HasFriendship(user))
                if (_friendsRepository.GetFriendship(user)
                   .Status == (int)FriendshipStatus.Accepted)
                    return _friendsRepository.DeleteFriendship(user);

            return false;

        }

        public FriendshipStatusDTO GetFriendship(UserFormDTO user)
        {
            var result = _friendsRepository.GetFriendship(user);
            if (result == null) return new FriendshipStatusDTO { Status=-1};

            return result;
        }

        public List<User> GetFriendshipRequests(UserFormDTO user)
        {
            return _friendsRepository.GetFriendshipRequests(user);
        }

        public List<User> GetUserFriends(UserFormDTO user)
        {
            return _friendsRepository.GetUserFriends(user);
        }

        public bool HasFriendship(UserFormDTO user)
        {
            return _friendsRepository.HasFriendship(user);
        }

        public bool HeSent(UserFormDTO user)
        {
            return _friendsRepository.HeSent(user);
        }

        public bool InsertFriendRequest(UserFormDTO user)
        {
            if (_friendsRepository.HasFriendship(user))
                if (_friendsRepository.GetFriendship(user)
                    .Status == (int)FriendshipStatus.Rejected)
                    return ReSentFriendRequest(user);
                else return false;

            return _friendsRepository.InsertFriendRequest(user);
        }

        public bool ReSentFriendRequest(UserFormDTO user)
        {
            return _friendsRepository.ReSentFriendRequest(user);
        }
    }
}
