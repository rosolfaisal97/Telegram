using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IPostReportService
    {
        bool CreatePostReport(ReportPost report_Post);
        List<ReportPost> GetAllPostReport();
        bool UpdatePostReport(ReportPost report_Post);
        bool DeletePostReport(int id);
        List<ReportPostJoinDto> GetAllReportPost();
    }
}
