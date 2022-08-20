using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class MediaGroupService : IMediaGroupService
    {
        private readonly IMediaGroupRepositery mediaGroupRepositery;
        public MediaGroupService (IMediaGroupRepositery _mediaGroupRepositery)
        {
            mediaGroupRepositery = _mediaGroupRepositery;
        }

        public bool CreateMediaGroup(MediaGroup mediaGroup)
        {
            return mediaGroupRepositery.CreateMediaGroup(mediaGroup);
        }

        public bool DeleteMediaGroup(int id)
        {
            return mediaGroupRepositery.DeleteMediaGroup(id);
        }

        public List<MediaGroup> GetAllMediaGroup()
        {
            return mediaGroupRepositery.GetAllMediaGroup();
        }

        public bool UpdateMediaGroup(MediaGroup mediaGroup)
        {
            return mediaGroupRepositery.UpdateMediaGroup(mediaGroup);
        }
    }
}
