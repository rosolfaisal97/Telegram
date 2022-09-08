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
        public List<User> GetUserFriends([FromQuery]UserFormDTO user)
        {
            return _friendsService.GetUserFriends(user);
        }

        [HttpGet]
        [ProducesResponseType(typeof(FriendshipStatusDTO), StatusCodes.Status200OK)]
        public FriendshipStatusDTO GetFriendship([FromQuery] UserFormDTO user)
        {
            return _friendsService.GetFriendship(user);
        }

        [HttpGet]
        public List<User> GetFriendshipRequests([FromQuery] UserFormDTO user)
        {
            return _friendsService.GetFriendshipRequests(user);

            

        }
    }
}