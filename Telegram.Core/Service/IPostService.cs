using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IPostService
    {
        bool CreatePost(Post post);
        List<Post> GetAllPost();
        bool UpdatePost(Post post);
        bool DeletePost(int id);
        List<Post> GetAllPostByChanel(int ch_id);
        List<PostJoinDto> AllPost();

    }
}
