using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class ChatMassageService : IChatMassageService
    {
        

        private readonly IChatMessage ChatMassageRepo;
        public ChatMassageService(IChatMessage ChatMassageRepo)
        {
            this.ChatMassageRepo = ChatMassageRepo;
        }
        public bool DeleteChatMessage(int? Ch__id)
        {
            return ChatMassageRepo.DeleteChatMessage(Ch__id);
        }

        public List<ChatMessage> GetAllChatMessage()
        {
            return ChatMassageRepo.GetAllChatMessage();
        }

        public ChatMessage InsertChatMessage(ChatMessage chat)
        {
            return ChatMassageRepo.InsertChatMessage(chat);
        }

        public List<ReturnMassageInfodto> ReturnMassageInfo(ReturnMassageInfodto massage)
        {
            return ChatMassageRepo.ReturnMassageInfo(massage);
        }

        public List<SearchMassageInfodto> SearchMassageInfo(SearchMassageInfodto searchmassage)
        {
            return ChatMassageRepo.SearchMassageInfo(searchmassage);
        }

        public bool UpdateChatMessage(ChatMessage chat)
        {
            return ChatMassageRepo.UpdateChatMessage(chat);
        }
    }
}
