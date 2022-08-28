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

        public bool DeleteMedia(MediaMessage mediaMessage)
        {
            return _mediaMsgRepository.DeleteMedia(mediaMessage);
        }

        public List<MediaMessage> GetAllMsgMedia(int msgId)
        {
            return _mediaMsgRepository.GetAllMsgMedia(msgId);
        }

        public bool InsertMedia(MediaMessage mediaMessage)
        {
            return _mediaMsgRepository.InsertMedia(mediaMessage);
        }
    }
}
