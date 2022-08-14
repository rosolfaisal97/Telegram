using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IFunctionChannelAdminService functionChannelAdminService ;
        public AdminController(IFunctionChannelAdminService functionChannelAdminService)
        {
            this.functionChannelAdminService = functionChannelAdminService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Top10PostByLike>), StatusCodes.Status200OK)]
        [Route("Top10Like")]
        public List<Top10PostByLike> Top10Like()
        {
            return functionChannelAdminService.GetTop10PostByLike();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Top10PostByComment>), StatusCodes.Status200OK)]
        [Route("Top10Comment")]
        public List<Top10PostByComment> Top10Comment()
        {
            return functionChannelAdminService.GetTop10PostByComment();
        }



        [HttpGet]
        [ProducesResponseType(typeof(List<ChannelsInfo>), StatusCodes.Status200OK)]
        [Route("ChannelsInfo")]
        public List<ChannelsInfo> ChannelsInfo()
        {
            return functionChannelAdminService.GetChannelsInfo();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountUserAdmin>), StatusCodes.Status200OK)]
        [Route("CountAdmin")]
        public List<CountUserAdmin> CountAdmin()
        {
            return functionChannelAdminService.GetCountUserAdmin();
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ChannelNameUserAdmin>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UserAdmin/{chid}")]
        public List<ChannelNameUserAdmin> UserAdmin(int chid)
        {
            return functionChannelAdminService.GetChannelNameUserAdmin(chid);
        }



        [HttpGet]
        [ProducesResponseType(typeof(List<GetChannelPosts>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetChannelPosts/{chid}")]
        public List<GetChannelPosts> GetChannelPosts(int chid)
        {
            return functionChannelAdminService.GetChannelPosts(chid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountMemberEachChannel>), StatusCodes.Status200OK)]
        [Route("CountMemberEachChannel")]
        public List<CountMemberEachChannel> CountMemberEachChannel()
        {
            return functionChannelAdminService.GetCountMemberEachChannel();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountReportEachPost>), StatusCodes.Status200OK)]
        [Route("CountReportEachPost")]
        public List<CountReportEachPost> CountReportEachPost()
        {
            return functionChannelAdminService.GetCountReportEachPost();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReportEachPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("ReportEachPost/{chid}")]
        public List<ReportEachPost> ReportEachPost(int chid)
        {
            return functionChannelAdminService.GetReportEachPost(chid);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<CountPostEachChannel>), StatusCodes.Status200OK)]
        [Route("CountPostEachChannel")]
        public List<CountPostEachChannel> CountPostEachChannel()
        {
            return functionChannelAdminService.GetCountPostEachChannel();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountReportEachPost>), StatusCodes.Status200OK)]
        [Route("CountFilterReportPostByType")]
        public List<CountFilterReportPostByType> CountFilterReportPostByType()
        {
            return functionChannelAdminService.GetCountFilterReportPostByType();
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<FilterReportPostByType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("FilterReportType")]
        public List<FilterReportPostByType> FilterReportType([FromBody] FilterReportPostByType type)
        {
            return functionChannelAdminService.GetFilterReportPostByType(type);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<MostReportPost>), StatusCodes.Status200OK)]
        [Route("MostReportPost")]
        public List<MostReportPost> MostReportPost()
        {
            return functionChannelAdminService.GetMostReportPost();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetMediaEachChannel>), StatusCodes.Status200OK)]
        [Route("GetMediaEachChannel/{CHid}")]
        public List<GetMediaEachChannel> GetMediaEachChannel(int CHid)
        {
            return functionChannelAdminService.GetMediaEachChannels(CHid);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<CountMediaEachChannel>), StatusCodes.Status200OK)]
        [Route("CountMediaEachChannel/{CHid}")]
        public List<CountMediaEachChannel> CountMediaEachChannel(int CHid)
        {
            return functionChannelAdminService.GetCountMediaEachChannel(CHid);
        }



        [HttpGet]
        [ProducesResponseType(typeof(List<ReportAcceptEachPost>), StatusCodes.Status200OK)]
        [Route("ReportAcceptEachPost/{Pid}")]
        public List<ReportAcceptEachPost> ReportAcceptEachPost(int Pid)
        {
            return functionChannelAdminService.GetReportAcceptEachPost(Pid);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<CountReportAcceptEachPost>), StatusCodes.Status200OK)]
        [Route("CountReportAcceptEachPost/{Pid}")]
        public List<CountReportAcceptEachPost> CountReportAcceptEachPost(int Pid)
        {
            return functionChannelAdminService.GetCountReportAcceptEachPost(Pid);
        }

    }
}
