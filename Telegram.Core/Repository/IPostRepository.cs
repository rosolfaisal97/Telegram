using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Repository
{
    public interface IPostRepository
    {
        bool CreatePost(Post post );
        List<Post> GetAllPost();
        bool UpdatePost(Post post );
        bool DeletePost(Post post);

    }
}
