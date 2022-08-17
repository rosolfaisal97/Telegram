using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class FunctionChannelAdminService : IFunctionChannelAdminService
    {
        private readonly IFunctionChannelAdminRepository FunctionChannelAdminRepository;

        public FunctionChannelAdminService(IFunctionChannelAdminRepository FunctionChannelAdminRepository)
        {
            this.FunctionChannelAdminRepository = FunctionChannelAdminRepository;
        }

        public List<ChannelNameUserAdmin> GetChannelNameUserAdmin(int Aid)
        {
            return FunctionChannelAdminRepository.GetChannelNameUserAdmin(Aid);
        }

        public List<GetChannelPosts> GetChannelPosts(int CHid)
        {
            return FunctionChannelAdminRepository.GetChannelPosts(CHid);
        }

        public List<ChannelsInfo> GetChannelsInfo()
        {
            return FunctionChannelAdminRepository.GetChannelsInfo();
        }

        public List<CountFilterReportPostByType> GetCountFilterReportPostByType()
        {
           return FunctionChannelAdminRepository.GetCountFilterReportPostByType();
        }

        public List<CountMediaEachChannel> GetCountMediaEachChannel(int CHid)
        {
            return FunctionChannelAdminRepository.GetCountMediaEachChannel(CHid);
        }

        public List<CountMemberEachChannel> GetCountMemberEachChannel()
        {
            return FunctionChannelAdminRepository.GetCountMemberEachChannel();
        }

        public List<CountPostEachChannel> GetCountPostEachChannel()
        {
           return FunctionChannelAdminRepository.GetCountPostEachChannel();
        }

        public List<CountReportAcceptEachPost> GetCountReportAcceptEachPost(int Pid)
        {
            return FunctionChannelAdminRepository.GetCountReportAcceptEachPost(Pid);
        }

        public List<CountReportEachPost> GetCountReportEachPost()
        {
            return FunctionChannelAdminRepository.GetCountReportEachPost();
        }

        public List<CountUserAdmin> GetCountUserAdmin()
        {
           return FunctionChannelAdminRepository.GetCountUserAdmin();
        }

        public List<FilterReportPostByType> GetFilterReportPostByType(FilterReportPostByType RType)
        {
            return FunctionChannelAdminRepository.GetFilterReportPostByType(RType);
        }

        public List<GetMediaEachChannel> GetMediaEachChannels(int CHid)
        {
            return FunctionChannelAdminRepository.GetMediaEachChannels(CHid);
        }

        public List<MostReportPost> GetMostReportPost()
        {
            return FunctionChannelAdminRepository.GetMostReportPost();
        }

        public List<ReportAcceptEachPost> GetReportAcceptEachPost(int Pid)
        {
            return FunctionChannelAdminRepository.GetReportAcceptEachPost(Pid);
        }

        public List<ReportEachPost> GetReportEachPost(int Pid)
        {
            return FunctionChannelAdminRepository.GetReportEachPost(Pid);
        }

        public List<Top10PostByComment> GetTop10PostByComment()
        {
            return FunctionChannelAdminRepository.GetTop10PostByComment();
        }

        public List<Top10PostByLike> GetTop10PostByLike()
        {
            return FunctionChannelAdminRepository.GetTop10PostByLike();
        }
    }
}
