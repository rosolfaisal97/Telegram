using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class PostMediaService: IPostMediaService
    {
        private readonly IPostMediaRepository PostMediaRepository;

        public PostMediaService(IPostMediaRepository PostMediaRepository)
        {
            this.PostMediaRepository = PostMediaRepository;
        }

        public bool CreatePostMedia(MediaPost media_Post)
        {
           return PostMediaRepository.CreatePostMedia(media_Post);
        }

        public bool DeletePostMedia(int id)
        {
           return PostMediaRepository.DeletePostMedia(id);
        }

        public List<MediaPost> GetAllPostMedia()
        {
            return PostMediaRepository.GetAllPostMedia();
        }

        public bool UpdatePostMedia(MediaPost media_Post)
        {
            return PostMediaRepository.UpdatePostMedia(media_Post);
        }
    }
}
