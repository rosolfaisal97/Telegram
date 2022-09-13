using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
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

        public List<PostJoinDto> AllPost()
        {
            return PostRepository.AllPost();
        }

        public bool CreatePost(Post post)
        {
            return PostRepository.CreatePost(post);
        }

        public bool DeletePost(int id)
        {
           return PostRepository.DeletePost(id);
        }

        public List<Post> GetAllPost()
        {
            return PostRepository.GetAllPost();
        }

        public List<Post> GetAllPostByChanel(int ch_id)
        {
            return PostRepository.GetAllPostByChanel(ch_id);
        }

        public bool UpdatePost(Post post)
        {
           return PostRepository.UpdatePost(post);
        }
    }
}
