using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IChatMassageService
    {
        public List<ChatMessage> GetAllChatMessage();
        public ChatMessage InsertChatMessage(ChatMessage chat);
        public bool UpdateChatMessage(ChatMessage chat);
        public bool DeleteChatMessage(ChatMessage chat);
        public List<SearchMassageInfodto> SearchMassageInfo(ChatMessage chat);
        public List<ReturnMassageInfodto> ReturnMassageInfo();

    }
}
