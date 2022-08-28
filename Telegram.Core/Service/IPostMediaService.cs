using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IPostMediaService
    {
        bool CreatePostMedia(MediaPost media_Post);
        List<MediaPost> GetAllPostMedia();
        bool UpdatePostMedia(MediaPost media_Post);
        bool DeletePostMedia(MediaPost media_Post);
    }
}
