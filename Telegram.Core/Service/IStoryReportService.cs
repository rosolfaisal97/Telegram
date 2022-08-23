using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IStoryReportService
    {
        public ReportStory Insert_story(ReportStory reportStory);
        public bool Update_report(ReportStory reportStory);
        public bool Delete_report(ReportStory reportStory);
        public List<GetAllReportStory> Get_All_Reports();
        public List<FilterByTypeDto> Filter_By_Type(string p_type);
        public List<CountStoryReport> Count_story_Report(int p_story_id);

        public List<GetAllStoryRepoDto> Get_All_story_Reports(int p_story_id);

    }
}
