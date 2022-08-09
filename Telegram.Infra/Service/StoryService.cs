using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class StoryService : IStoryService
    {
          
        private readonly IStory StoryRepo;
        public StoryService(IStory StoryRepo)
        {
            this.StoryRepo = StoryRepo;
        }
        public bool DeleteStory(int? S_id)
        {
            return StoryRepo.DeleteStory(S_id);
        }

        public List<Story> GetAllStory()
        {
            return StoryRepo.GetAllStory();
        }

        public Story InsertStory(Story story)
        {
            return StoryRepo.InsertStory(story);
        }

        public List<ReturnUserInfodto> ReturnUserInfo(ReturnUserInfodto userinfo)
        {
            return StoryRepo.ReturnUserInfo(userinfo);
        }

        public bool UpdateStory(Story story)
        {
            return StoryRepo.UpdateStory(story);
        }
    }
}
