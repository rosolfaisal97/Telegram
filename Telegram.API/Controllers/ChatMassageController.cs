using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;
using Telegram.Infra.Repoisitory;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    // [Authorize]
    public class ChatMassageController : ControllerBase
    {
        private readonly IChatMassageService ChatMassageService;
        public ChatMassageController(IChatMassageService ChatMassageService)
        {
            this.ChatMassageService = ChatMassageService;
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "User,Admin")]
        public bool DeleteChatMessage([FromBody] ChatMessage chat)
        {
            return ChatMassageService.DeleteChatMessage(chat);
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public List<ChatMessage> GetAllChatMessage()
        {
            return ChatMassageService.GetAllChatMessage();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ChatMessage InsertChatMessage([FromBody] ChatMessage chat)
        {
            return ChatMassageService.InsertChatMessage(chat);
        }

        [HttpPost("ReturnMassageInfo")]
        [Authorize(Roles = "User,Admin")]
        public List<ReturnMassageInfodto> ReturnMassageInfo()
        {
            return ChatMassageService.ReturnMassageInfo();
        }

        [HttpPost("SearchMassage")]
        [Authorize(Roles = "Admin")]
        public List<SearchMassageInfodto> SearchMassageInfo([FromBody] ChatMessage chat)

        {
            return ChatMassageService.SearchMassageInfo(chat);
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        public bool UpdateChatMessage([FromBody] ChatMessage chat)
        {
            return ChatMassageService.UpdateChatMessage(chat);
        }

        //qasem
        [HttpGet]
        [Route("{userFromId}/{userToId}")]
        public List<UserChatFormDTO> GetUserFriendChat(int userFromId, int userToId)
        {
            return ChatMassageService.GetUserFriendChat(userFromId, userToId);
        }
    }
}
