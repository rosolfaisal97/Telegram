using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class StoryController : ControllerBase
    {
       
        private readonly IStoryService IStoryService;
        public StoryController(IStoryService IStoryService)
        {
            this.IStoryService = IStoryService;
        }
        [HttpDelete]
        [ProducesResponseType(typeof(List<Story>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{S_id}")]
        public bool DeleteStory(int S_id)
        {
            return IStoryService.DeleteStory(S_id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Story>), StatusCodes.Status200OK)]
        public List<Story> GetAllStory()
        {
            return IStoryService.GetAllStory();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Story), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Story InsertStory([FromBody]Story story)
        {
            return IStoryService.InsertStory(story);
        }

        [HttpPost("UserInfo/{S_user_id}")]
        public List<ReturnUserInfodto> ReturnUserInfo(int S_user_id)
        {
            return IStoryService.ReturnUserInfo(S_user_id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<Story>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateStory([FromBody]Story story)
        {
            return IStoryService.UpdateStory(story);
        }
    }
}
