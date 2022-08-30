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
    //[Authorize]
    public class StoryController : ControllerBase
    {
       
        private readonly IStoryService IStoryService;
        public StoryController(IStoryService IStoryService)
        {
            this.IStoryService = IStoryService;
        }
        [HttpDelete]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<Story>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]

        public bool DeleteStory(Story story)
        {
            return IStoryService.DeleteStory(story);
        }

        [HttpGet]
        // [Authorize(Roles = "Admin")]
 
        [ProducesResponseType(typeof(List<Story>), StatusCodes.Status200OK)]
        public List<Story> GetAllStory()
        {
            return IStoryService.GetAllStory();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Story), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Story InsertStory([FromBody]Story story)
        {
            return IStoryService.InsertStory(story);
        }

        [HttpPost("UserInfo")]
        [Authorize(Roles = "Admin")]
        public List<ReturnUserInfodto> ReturnUserInfo(Story story)
        {
            return IStoryService.ReturnUserInfo(story);
        }

        [HttpPut]
        //[Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<Story>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateStory([FromBody]Story story)
        {
            return IStoryService.UpdateStory(story);
        }
    }
}
