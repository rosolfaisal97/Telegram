using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MediaMessageController : Controller
    {
        private readonly IMediaMsgService _mediaMsgService;
        public MediaMessageController(IMediaMsgService mediaMsgService)
        {
            _mediaMsgService = mediaMsgService;
        }

        public bool InsertMedia(string filePath, string caption, int msgId)
        {
            return _mediaMsgService.InsertMedia(filePath, caption, msgId);
        }
        public bool DeleteMedia(int msgId)
        {
            return _mediaMsgService.DeleteMedia(msgId);
        }
        public List<MediaMessage> GetAllMsgMedia(int msgId)
        {
            return _mediaMsgService.GetAllMsgMedia(msgId);
        }

    }
}
