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
        public bool DeleteChatMessage(ChatMessage chat)
        {
            return ChatMassageRepo.DeleteChatMessage(chat);
        }

        public List<ChatMessage> GetAllChatMessage()
        {
            return ChatMassageRepo.GetAllChatMessage();
        }

       

        public ChatMessage InsertChatMessage(ChatMessage chat)
        {
            return ChatMassageRepo.InsertChatMessage(chat);
        }

        public List<ReturnMassageInfodto> ReturnMassageInfo()
        {
            return ChatMassageRepo.ReturnMassageInfo();
        }

        public List<SearchMassageInfodto> SearchMassageInfo(ChatMessage chat)
        {
            return ChatMassageRepo.SearchMassageInfo(chat);
        }

        public bool UpdateChatMessage(ChatMessage chat)
        {
            return ChatMassageRepo.UpdateChatMessage(chat);
        }


        public List<UserChatFormDTO> GetUserFriendChat(int userFromId, int userToId)
        {
            return ChatMassageRepo.GetUserFriendChat(userFromId, userToId);
        }
    }
}
