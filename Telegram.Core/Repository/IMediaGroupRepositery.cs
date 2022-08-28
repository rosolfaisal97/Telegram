using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Repository
{
    public interface IMediaGroupRepositery
    {
        bool CreateMediaGroup(MediaGroup mediaGroup);
        List<MediaGroup> GetAllMediaGroup();
        bool UpdateMediaGroup(MediaGroup mediaGroup);
        bool DeleteMediaGroup(MediaGroup mediaGroup);
    }
}
