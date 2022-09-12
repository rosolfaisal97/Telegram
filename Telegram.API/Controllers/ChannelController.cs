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
  //  [Authorize]
    public class ChannelController : Controller
    {
        private readonly IChannelService ChannelService;
        public ChannelController(IChannelService ChannelService)
        {
            this.ChannelService = ChannelService;
        }




        [HttpPost]
        [Route("UploadImagepost")]
        public Creatpost UploadImagepost()
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
                var fullPath = Path.Combine("F:\\NewTelegram\\Telegram\\src\\assets\\img", attachmentFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Creatpost Item = new Creatpost();
                Item.file_path = fileName;
                return Item;
            }
            catch (Exception)
            {
                return null;
            }

        }



        [HttpPost]
       // [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Creatpost), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePost([FromBody] Creatpost creatpost )
        {
            return ChannelService.CreatePost(creatpost);
        }



        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        public List<Channel> GetAllChannel()
        {
            return ChannelService.GetAllChannel();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Channel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateChannel([FromBody] Channel Channel)
        {
            return ChannelService.CreateChannel(Channel);
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateChannel([FromBody] Channel Channel)
        {
            return ChannelService.UpdateChannel(Channel);
        }

        [HttpDelete]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(List<Channel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool DeleteChannel([FromBody] Channel channel)
        {
            return ChannelService.DeleteChannel(channel);
        }

    }
}
