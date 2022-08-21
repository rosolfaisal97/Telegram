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
        public bool DeleteStory(Story story)
        {
            return StoryRepo.DeleteStory(story);
        }

        public List<Story> GetAllStory()
        {
            return StoryRepo.GetAllStory();
        }

        public Story InsertStory(Story story)
        {
            return StoryRepo.InsertStory(story);
        }

        public List<ReturnUserInfodto> ReturnUserInfo(Story story)
        {
            return StoryRepo.ReturnUserInfo(story);
        }

        public bool UpdateStory(Story story)
        {
            return StoryRepo.UpdateStory(story);
        }
    }
}
