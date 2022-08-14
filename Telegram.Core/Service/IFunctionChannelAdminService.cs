using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IFunctionChannelAdminService
    {

        List<Top10PostByLike> GetTop10PostByLike();
        List<Top10PostByComment> GetTop10PostByComment();
        List<ChannelsInfo> GetChannelsInfo();
        List<CountUserAdmin> GetCountUserAdmin();
        List<GetChannelPosts> GetChannelPosts(int CHid);

        List<ChannelNameUserAdmin> GetChannelNameUserAdmin(int Aid);
        List<CountMemberEachChannel> GetCountMemberEachChannel();
        List<CountReportEachPost> GetCountReportEachPost();
        List<ReportEachPost> GetReportEachPost(int Pid);

        List<CountPostEachChannel> GetCountPostEachChannel();
        List<CountFilterReportPostByType> GetCountFilterReportPostByType();
        List<FilterReportPostByType> GetFilterReportPostByType(FilterReportPostByType RType);
        List<MostReportPost> GetMostReportPost();

        List<GetMediaEachChannel> GetMediaEachChannels(int CHid);
        List<CountMediaEachChannel> GetCountMediaEachChannel(int CHid);
        List<CountReportAcceptEachPost> GetCountReportAcceptEachPost(int Pid);
        List<ReportAcceptEachPost> GetReportAcceptEachPost(int Pid);
    }
}
