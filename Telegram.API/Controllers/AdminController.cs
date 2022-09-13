using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IFunctionChannelAdminService functionChannelAdminService ;
        public AdminController(IFunctionChannelAdminService functionChannelAdminService)
        {
            this.functionChannelAdminService = functionChannelAdminService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Top10PostByLike>), StatusCodes.Status200OK)]
       // [Route("Top10Like")]
        public List<Top10PostByLike> Top10Like()
        {
            return functionChannelAdminService.GetTop10PostByLike();
        }

        [HttpGet]
       [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Top10PostByComment>), StatusCodes.Status200OK)]
        //[Route("Top10Comment")]
        public List<Top10PostByComment> Top10Comment()
        {
            return functionChannelAdminService.GetTop10PostByComment();
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<ChannelsInfo>), StatusCodes.Status200OK)]
       // [Route("ChannelsInfo")]

        public List<ChannelsInfo> ChannelsInfo()
        {
            return functionChannelAdminService.GetChannelsInfo();
        }

        [HttpGet]
       [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<CountUserAdmin>), StatusCodes.Status200OK)]
       // [Route("CountAdmin")]
        public List<CountUserAdmin> CountAdmin()
        {
            return functionChannelAdminService.GetCountUserAdmin();
        }

 
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<CountMemberEachChannel>), StatusCodes.Status200OK)]
        //[Route("CountMemberEachChannel")]
        public List<CountMemberEachChannel> CountMemberEachChannel()
        {
            return functionChannelAdminService.GetCountMemberEachChannel();
        }

        [HttpGet]
       [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<CountReportEachPost>), StatusCodes.Status200OK)]
        //[Route("CountReportEachPost")]
        public List<CountReportEachPost> CountReportEachPost()
        {
            return functionChannelAdminService.GetCountReportEachPost();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<ReportEachPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("ReportEachPost/{chid}")]
        public List<ReportEachPost> ReportEachPost(int chid)
        {
            return functionChannelAdminService.GetReportEachPost(chid);
        }


        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<CountPostEachChannel>), StatusCodes.Status200OK)]
        [Route("CountPostEachChannel")]
        public List<CountPostEachChannel> CountPostEachChannel()
        {
            return functionChannelAdminService.GetCountPostEachChannel();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<CountReportEachPost>), StatusCodes.Status200OK)]
        [Route("CountFilterReportPostByType")]
        public List<CountFilterReportPostByType> CountFilterReportPostByType()
        {
            return functionChannelAdminService.GetCountFilterReportPostByType();
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(List<FilterReportPostByType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("FilterReportType")]
        public List<FilterReportPostByType> FilterReportType([FromBody] FilterReportPostByType type)
        {
            return functionChannelAdminService.GetFilterReportPostByType(type);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<MostReportPost>), StatusCodes.Status200OK)]
        [Route("MostReportPost")]
        public List<MostReportPost> MostReportPost()
        {
            return functionChannelAdminService.GetMostReportPost();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<GetMediaEachChannel>), StatusCodes.Status200OK)]
        [Route("GetMediaEachChannel/{CHid}")]
        public List<GetMediaEachChannel> GetMediaEachChannel(int CHid)
        {
            return functionChannelAdminService.GetMediaEachChannels(CHid);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<CountMediaEachChannel>), StatusCodes.Status200OK)]
        [Route("CountMediaEachChannel/{CHid}")]
        public List<CountMediaEachChannel> CountMediaEachChannel(int CHid)
        {
            return functionChannelAdminService.GetCountMediaEachChannel(CHid);
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<ReportAcceptEachPost>), StatusCodes.Status200OK)]
        [Route("ReportAcceptEachPost/{Pid}")]
        public List<ReportAcceptEachPost> ReportAcceptEachPost(int Pid)
        {
            return functionChannelAdminService.GetReportAcceptEachPost(Pid);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<CountReportAcceptEachPost>), StatusCodes.Status200OK)]
        [Route("CountReportAcceptEachPost/{Pid}")]
        public List<CountReportAcceptEachPost> CountReportAcceptEachPost(int Pid)
        {
            return functionChannelAdminService.GetCountReportAcceptEachPost(Pid);
        }

    }
}
