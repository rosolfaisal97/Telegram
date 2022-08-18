using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IMediaGroupService
    {
        bool CreateMediaGroup(MediaGroup mediaGroup);
        List<MediaGroup> GetAllMediaGroup();
        bool UpdateMediaGroup(MediaGroup mediaGroup);
        bool DeleteMediaGroup(int id);
    }
}
