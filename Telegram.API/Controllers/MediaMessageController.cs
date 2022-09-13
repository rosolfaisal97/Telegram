using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MediaMessageController : Controller
    {
        private readonly IMediaMsgService _mediaMsgService;
        public MediaMessageController(IMediaMsgService mediaMsgService)
        {
            _mediaMsgService = mediaMsgService;
        }

        [HttpPost]
        [Authorize]
        public bool InsertMedia([FromBody] MediaMessage mediaMessage)
        {
            return _mediaMsgService.InsertMedia(mediaMessage);
        }
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public bool DeleteMedia([FromBody] MediaMessage mediaMessage)
        {
            return _mediaMsgService.DeleteMedia(mediaMessage);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{messageId}")]
        public List<MediaMessage> GetAllMsgMedia(int msgId)
        {
            return _mediaMsgService.GetAllMsgMedia(msgId);
        }

    }
}
