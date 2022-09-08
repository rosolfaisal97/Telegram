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
    //[Authorize]
    public class FriendsController : Controller
    {
        private readonly IFriendsService _friendsService;
        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }


        [HttpPost]
        public bool InsertFriendRequest([FromBody] UserFormDTO user)
        {
            return _friendsService.InsertFriendRequest(user);


        }


        [HttpPost]
        public bool DeleteFriendRequest([FromBody] UserFormDTO user)
        {
            return _friendsService.DeleteFriendRequest(user);
        }

        [HttpPost]
        public bool AcceptFriendRequest([FromBody] UserFormDTO user)
        {
            return _friendsService.AcceptFriendRequest(user);
        }

        [HttpPost]
        public bool DeleteFriendship([FromBody] UserFormDTO user)
        {
            return _friendsService.DeleteFriendship(user);
        }

        [HttpPost]
        public bool HasFriendship([FromBody] UserFormDTO user)
        {
            return _friendsService.HasFriendship(user);
        }

        [HttpPost]
        public bool HeSent([FromBody] UserFormDTO user)
        {
            return _friendsService.HeSent(user);
        }

        [HttpGet]
        [Route("{userFromId}")]
        public List<User> GetUserFriends(int userFromId)
        {
            return _friendsService.GetUserFriends(new UserFormDTO { UserFromId = userFromId });
        }

        [HttpGet]
        [ProducesResponseType(typeof(FriendshipStatusDTO), StatusCodes.Status200OK)]
        [Route("{userFromId}/{userToId}")]

        public FriendshipStatusDTO GetFriendship(int userFromId, int userToId)
        {
            return _friendsService.GetFriendship(new UserFormDTO
            {
                UserFromId = userFromId,
                UserToId = userToId
            });
        }

        [HttpGet]
        [Route("{userFromId}")]
        public List<User> GetFriendshipRequests(int userFromId)
        {
            return _friendsService.GetFriendshipRequests(new UserFormDTO
            {
                UserFromId = userFromId
            });
        }
    }
}