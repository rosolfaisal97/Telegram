using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class FunctionChannelUserService : IFunctionChannelUserService
    {
        private readonly IFunctionChannelUserRepository FunctionChannelUserRepository;

        public FunctionChannelUserService(IFunctionChannelUserRepository FunctionChannelUserRepository)
        {
            this.FunctionChannelUserRepository = FunctionChannelUserRepository;
        }

        public List<ChannelsSubscribed> ChannelsSubscribed(int Cid)
        {
            return FunctionChannelUserRepository.ChannelsSubscribed(Cid);
        }

        public List<AdminsChannelName> GetAdminsChannelName(int Cid)
        {
            return FunctionChannelUserRepository.GetAdminsChannelName(Cid);
        }

        public List<ChannelFiles> GetChannelFiles(int Cid)
        {
            return FunctionChannelUserRepository.GetChannelFiles(Cid);
        }

        public List<MemberChannel> GetChannelMember(int Cid)
        {
           return FunctionChannelUserRepository.GetChannelMember(Cid);
        }

        public List<ChannelPosts> GetChannelPosts(int Cid)
        {
           return FunctionChannelUserRepository.GetChannelPosts(Cid);
        }

        public List<ChannelProfile> GetChannelProfile(int Cid)
        {
            return FunctionChannelUserRepository.GetChannelProfile(Cid);
        }

        public List<CheckReprort> GetCheckReprort(int Pid)
        {
            return FunctionChannelUserRepository.GetCheckReprort(Pid);
        }

        public List<CommentPost> GetCommentPost(int Pid)
        {
            return FunctionChannelUserRepository.GetCommentPost(Pid);
        }

        public List<CountAdminsChannel> GetCountAdminsChannel(int Cid)
        {
            return FunctionChannelUserRepository.GetCountAdminsChannel(Cid);
        }

        public List<CountChannelFiles> GetCountChannelFiles(int Cid)
        {
            return FunctionChannelUserRepository.GetCountChannelFiles(Cid);
        }

        public List<CountChannelMember> GetCountChannelMember(int Cid)
        {
            return FunctionChannelUserRepository.GetCountChannelMember(Cid);

        }

        public List<CountChannelPosts> GetCountChannelPosts(int Cid)
        {
            return FunctionChannelUserRepository.GetCountChannelPosts(Cid);
        }

        public List<CountCommentPost> GetCountCommentPost(int Pid)
        {
           return FunctionChannelUserRepository.GetCountCommentPost(Pid);
        }

        public List<CountLikePost> GetCountLikePost(int Pid)
        {
           return FunctionChannelUserRepository.GetCountLikePost(Pid);
        }

        public List<FilesPost> GetFilesPost(int Pid)
        {
            return FunctionChannelUserRepository.GetFilesPost(Pid);
        }

        public List<FilterChannelByMember> GetFilterChannelByMember(FilterChannelByMember filterChannelByMember)
        {
            return FunctionChannelUserRepository.GetFilterChannelByMember(filterChannelByMember);
        }

        public List<FilterChannelPost> GetFilterChannelPost(FilterChannelPost filterChannel)
        {
           return FunctionChannelUserRepository.GetFilterChannelPost(filterChannel);
        }

        public List<LikePost> GetLikePost(int Pid)
        {
            return FunctionChannelUserRepository.GetLikePost(Pid);
        }

        public List<OwnerChannelName> GetOwnerChannelName(int Cid)
        {
            return FunctionChannelUserRepository.GetOwnerChannelName(Cid);
        }

        public List<PostReprortInfo> GetPostReprortInfo(int Pid)
        {
            return FunctionChannelUserRepository.GetPostReprortInfo(Pid);
        }
    }
}
