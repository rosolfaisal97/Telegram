using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IMediaMsgService
    {
        bool InsertMedia(MediaMessage mediaMessage);
        bool DeleteMedia(MediaMessage mediaMessage);
        List<MediaMessage> GetAllMsgMedia(int msgId);
    }
}
