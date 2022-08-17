using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class PostReportService : IPostReportService
    {
        private readonly IPostReportRepository PostReportRepository;

        public PostReportService(IPostReportRepository PostReportRepository)
        {
            this.PostReportRepository = PostReportRepository;
        }

        public bool CreatePostReport(ReportPost report_Post)
        {
            return PostReportRepository.CreatePostReport(report_Post);  
        }

        public bool DeletePostReport(int id)
        {
           return PostReportRepository.DeletePostReport(id);
        }

        public List<ReportPost> GetAllPostReport()
        {
           return PostReportRepository.GetAllPostReport();
        }

        public bool UpdatePostReport(ReportPost report_Post)
        {
            return PostReportRepository.UpdatePostReport(report_Post);
        }
    }
}
