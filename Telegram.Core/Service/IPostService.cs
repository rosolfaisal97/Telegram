using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IPostService
    {
        bool CreatePost(Post post);
        List<Post> GetAllPost();
        bool UpdatePost(Post post);
        bool DeletePost(int id);
    }
}
