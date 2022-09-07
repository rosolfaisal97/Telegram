using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class PostReportController : ControllerBase
    {

        private readonly IPostReportService PostReportService;
        public PostReportController(IPostReportService PostReportService)
        {
            this.PostReportService = PostReportService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ReportPost>), StatusCodes.Status200OK)]
        public List<ReportPost> GetAllPostReport()
        {
            return PostReportService.GetAllPostReport();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReportPost), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePostReport([FromBody] ReportPost PostReport)
        {
            return PostReportService.CreatePostReport(PostReport);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<ReportPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePostReport([FromBody] ReportPost PostReport)
        {
            return PostReportService.UpdatePostReport(PostReport);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<ReportPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeletePostReport(int id)
        {
            return PostReportService.DeletePostReport(id);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ReportPostJoinDto>), StatusCodes.Status200OK)]
        public List<ReportPostJoinDto> GetAllReportPost()
        {
            return PostReportService.GetAllReportPost();
        }

    }
}
