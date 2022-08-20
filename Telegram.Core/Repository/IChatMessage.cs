﻿using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface IChatMessage
    {
        public List<ChatMessage> GetAllChatMessage();
        public ChatMessage InsertChatMessage(ChatMessage chat);
        public bool UpdateChatMessage(ChatMessage chat);
        public bool DeleteChatMessage(int Ch__id);
        public List<SearchMassageInfodto> SearchMassageInfo( string search_m ,int Ch_user_from , int Ch_user_to   );
        public List<ReturnMassageInfodto> ReturnMassageInfo();

    }
}
