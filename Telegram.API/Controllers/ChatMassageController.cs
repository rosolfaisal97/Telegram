using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatMassageController : ControllerBase
    {
        private readonly IChatMassageService ChatMassageService;
        public ChatMassageController(IChatMassageService ChatMassageService)
        {
            this.ChatMassageService = ChatMassageService;
        }

        [HttpDelete("delete/{Ch__id}")]
        public bool DeleteChatMessage(int? Ch__id)
        {
            return ChatMassageService.DeleteChatMessage(Ch__id);
        }

        [HttpGet]
        public List<ChatMessage> GetAllChatMessage()
        {
            return ChatMassageService.GetAllChatMessage();
        }

        [HttpPost]
        public ChatMessage InsertChatMessage([FromBody] ChatMessage chat)
        {
            return ChatMassageService.InsertChatMessage(chat);
        }

        [HttpPost ("ReturnMassageInfo")]
        public List<ReturnMassageInfodto> ReturnMassageInfo([FromBody] ReturnMassageInfodto massage)
        {
            return ChatMassageService.ReturnMassageInfo(massage);
        }

        [HttpPost("SearchMassage")]
        public List<SearchMassageInfodto> SearchMassageInfo([FromBody] SearchMassageInfodto searchmassage)
        {
            return ChatMassageService.SearchMassageInfo(searchmassage);
        }

        [HttpPut]
        public bool UpdateChatMessage([FromBody] ChatMessage chat)
        {
            return ChatMassageService.UpdateChatMessage(chat);
        }
    }
}
