using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Repository
{
    public interface IMediaMsgRepository
    {
        
        bool InsertMedia(string filePath, string caption, int msgId);
        bool DeleteMedia(int msgId);
        List<MediaMessage> GetAllMsgMedia(int msgId);

    }
}
