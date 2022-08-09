using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface IFunctionChannelUserRepository
    {
        List<AdminsChannelName> GetAdminsChannelName(int Cid);
        List<OwnerChannelName> GetOwnerChannelName(int Cid);
        List<MemberChannel> GetChannelMember(int Cid);
        List<ChannelPosts> GetChannelPosts(int Cid);
        List<ChannelFiles> GetChannelFiles(int Cid);

        List<CountAdminsChannel> GetCountAdminsChannel(int Cid);
        List<CountChannelMember> GetCountChannelMember(int Cid);
        List<CountChannelPosts> GetCountChannelPosts(int Cid);
        List<CountChannelFiles> GetCountChannelFiles(int Cid);


        List<CountCommentPost> GetCountCommentPost(int Pid);
        List<CountLikePost> GetCountLikePost(int Pid);



        List<ChannelProfile> GetChannelProfile(int Cid);

        List<CommentPost> GetCommentPost(int Pid);
        List<LikePost> GetLikePost(int Pid);
        List<FilesPost> GetFilesPost(int Pid);


        List<PostReprortInfo> GetPostReprortInfo(int Pid);
        List<CheckReprort> GetCheckReprort(int Pid);

        List<FilterChannelByMember> GetFilterChannelByMember(FilterChannelByMember filterChannelByMember);
        List<FilterChannelPost> GetFilterChannelPost(FilterChannelPost filterChannel);






    }
}
