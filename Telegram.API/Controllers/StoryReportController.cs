using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryReportController : ControllerBase
    {
         
        private readonly IStoryReportService storyReportService;
        public StoryReportController(IStoryReportService storyReportService)
        {
            this.storyReportService = storyReportService;
        }
        [HttpDelete]
        [ProducesResponseType(typeof(List<ReportStory>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool Delete_report([FromBody]ReportStory reportStory)
        {
            return storyReportService.Delete_report(reportStory);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllReportStory>), StatusCodes.Status200OK)]
        public List<GetAllReportStory> Get_All_Reports()
        {
            return storyReportService.Get_All_Reports();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReportStory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ReportStory Insert_story([FromBody] ReportStory reportStory)
        {
            return storyReportService.Insert_story(reportStory);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<ReportStory>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update_report([FromBody] ReportStory reportStory)
        {
            return storyReportService.Update_report(reportStory);
        }


        [HttpGet("GetAllStory/{p_story_id}")]
        [ProducesResponseType(typeof(List<GetAllStoryRepoDto>), StatusCodes.Status200OK)]
        public List<GetAllStoryRepoDto> Get_All_story_Reports(int p_story_id)
        {
            return storyReportService.Get_All_story_Reports(p_story_id);
        }
        [HttpGet("Filter_By_Type/{p_type}")]
        [ProducesResponseType(typeof(List<FilterByTypeDto>), StatusCodes.Status200OK)]
        public List<FilterByTypeDto> Filter_By_Type(string p_type)
        {
            return storyReportService.Filter_By_Type(p_type);
        }
        [HttpGet("Count_story/{p_story_id}")]
        [ProducesResponseType(typeof(List<CountStoryReport>), StatusCodes.Status200OK)]
        public List<CountStoryReport> Count_story_Report(int p_story_id)
        {
            return storyReportService.Count_story_Report(p_story_id);
        }
    }
}

