using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface IStory
    {
        public List<Story> GetAllStory();
        public Story InsertStory(Story story);
        public bool UpdateStory(Story story);
        public bool DeleteStory(int? S_id);
        public List<ReturnUserInfodto> ReturnUserInfo(ReturnUserInfodto userinfo);
    }
}
