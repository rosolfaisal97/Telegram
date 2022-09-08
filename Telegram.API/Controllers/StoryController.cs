using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        
        [ProducesResponseType(typeof(Story), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Story InsertStory([FromBody]Story story)
        {
            return IStoryService.InsertStory(story);
        }

        [HttpPost("UserInfo")]
        
        public List<ReturnUserInfodto> ReturnUserInfo(Story story)
        {
            return IStoryService.ReturnUserInfo(story);
        }


        [HttpPost]
        [Route("UploadImageUser")]
        public Story UploadImageUser()
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    fileContent = stream.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var attachmentFileName = $"{fileName}{Path.GetExtension(file.Name)}";
                var fullPath = Path.Combine("F:\\Telegram\\Telegram\\src\\assets\\img", attachmentFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Story Item = new Story();
                Item.file_path = fileName;
                return Item;
            }
            catch (Exception)
            {
                return null;
            }

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
