using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FriendsController : Controller
    {
        private readonly IFriendsService _friendsService;
        //[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]


        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }


        [HttpPost]
        [Route("{userFrom}/{userTo}")]
        public bool InsertFriendRequest(int userFrom, int userTo)
        {
            return _friendsService.InsertFriendRequest(userFrom, userTo);
        }


        [HttpPost]
        [Route("{userFrom}/{userTo}")]
        public bool DeleteFriendRequest(int userFrom, int userTo)
        {
            return _friendsService.DeleteFriendRequest(userFrom, userTo);
        }

        [HttpPost]
        [Route("{userFrom}/{userTo}")]
        public bool AcceptFriendRequest(int userFrom, int userTo)
        {
            return _friendsService.AcceptFriendRequest(userFrom, userTo);
        }

        [HttpPost]
        [Route("{userFrom}/{userTo}")]
        public bool DeleteFriendship(int userFrom, int userTo)
        {
            return _friendsService.DeleteFriendship(userFrom, userTo);
        }

        [HttpPost]
        [Route("{userFrom}/{userTo}")]
        public bool HasFriendship(int userFrom, int userTo)
        {
            return _friendsService.HasFriendship(userFrom, userTo);

        }

        [HttpPost]
        [Route("{userFrom}/{userTo}")]
        public bool HeSent(int userFrom, int userTo)
        {
            return _friendsService.HeSent(userFrom, userTo);
        }

        [HttpGet]
        [Route("{userFrom}")]
        public List<User> GetUserFriends(int userFrom)
        {
            return _friendsService.GetUserFriends(userFrom);
        }

        [HttpGet]
        [Route("{userFrom}/{userTo}")]
        [ProducesResponseType(typeof(FriendshipStatusDTO), StatusCodes.Status200OK)]
        public FriendshipStatusDTO GetFriendship(int userFrom, int userTo)
        {
            return _friendsService.GetFriendship(userFrom, userTo);
        }

        [HttpGet]
        [Route("{userFrom}")]
        public List<User> GetFriendshipRequests(int userFrom)
        {
            return _friendsService.GetFriendshipRequests(userFrom);
        }







    }
}
