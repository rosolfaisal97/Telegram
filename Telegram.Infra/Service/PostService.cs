using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository PostRepository;

        public PostService(IPostRepository PostRepository)
        {
            this.PostRepository = PostRepository;
        }

        public bool CreatePost(Post post)
        {
            return PostRepository.CreatePost(post);
        }

        public bool DeletePost(Post post)
        {
           return PostRepository.DeletePost(post);
        }

        public List<Post> GetAllPost()
        {
            return PostRepository.GetAllPost();
        }

        public bool UpdatePost(Post post)
        {
           return PostRepository.UpdatePost(post);
        }
    }
}
