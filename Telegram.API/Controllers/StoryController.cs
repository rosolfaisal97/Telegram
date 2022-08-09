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
    public class StoryController : ControllerBase
    {
       
        private readonly IStoryService IStoryService;
        public StoryController(IStoryService IStoryService)
        {
            this.IStoryService = IStoryService;
        }
        [HttpDelete("delete/{S_id}")]
        public bool DeleteStory(int? S_id)
        {
            return IStoryService.DeleteStory(S_id);
        }

        [HttpGet]
        public List<Story> GetAllStory()
        {
            return IStoryService.GetAllStory();
        }

        [HttpPost]
        public Story InsertStory([FromBody]Story story)
        {
            return IStoryService.InsertStory(story);
        }

        [HttpPost("UserInfo")]
        public List<ReturnUserInfodto> ReturnUserInfo([FromBody] ReturnUserInfodto userinfo)
        {
            return IStoryService.ReturnUserInfo(userinfo);
        }

        [HttpPut]
        public bool UpdateStory([FromBody]Story story)
        {
            return IStoryService.UpdateStory(story);
        }
    }
}
