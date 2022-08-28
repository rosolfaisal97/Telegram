using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class storyReportService: IStoryReportService
    {
        
        private readonly IStoryReportRepository StoryReportRepository;
        public storyReportService(IStoryReportRepository StoryReportRepository)
        {
            this.StoryReportRepository = StoryReportRepository;
        }

        public bool Delete_report(ReportStory reportStory)
        {
            return StoryReportRepository.Delete_report(reportStory);
        }

        public List<GetAllReportStory> Get_All_Reports()
        {
            return StoryReportRepository.Get_All_Reports();
        }

        public List<GetAllStoryRepoDto> Get_All_story_Reports(int p_story_id)
        {
            return StoryReportRepository.Get_All_story_Reports(p_story_id);
        }

        public ReportStory Insert_story(ReportStory reportStory)
        {
            return StoryReportRepository.Insert_story(reportStory);
        }

        public bool Update_report(ReportStory reportStory)
        {
            return StoryReportRepository.Update_report(reportStory);
        }
        public List<FilterByTypeDto> Filter_By_Type(string p_type)
        {
            return StoryReportRepository.Filter_By_Type(p_type);
        }
        public List<CountStoryReport> Count_story_Report(int p_story_id)
        {
            return StoryReportRepository.Count_story_Report(p_story_id);
        }
    }
}
