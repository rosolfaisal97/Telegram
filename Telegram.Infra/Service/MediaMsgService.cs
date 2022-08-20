using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class MediaMsgService : IMediaMsgService
    {
        private readonly IMediaMsgRepository _mediaMsgRepository;
        public MediaMsgService(IMediaMsgRepository mediaMsgRepository)
        {
            _mediaMsgRepository = mediaMsgRepository;
        }

        public bool DeleteMedia(int msgId)
        {
            return _mediaMsgRepository.DeleteMedia(msgId);
        }

        public List<MediaMessage> GetAllMsgMedia(int msgId)
        {
            return _mediaMsgRepository.GetAllMsgMedia(msgId);
        }

        public bool InsertMedia(string filePath, string caption, int msgId)
        {
            return _mediaMsgRepository.InsertMedia(filePath, caption, msgId);
        }
    }
}
