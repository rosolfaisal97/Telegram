using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Repository
{
    public interface IPostReportRepository
    {
        bool CreatePostReport(ReportPost report_Post );
        List<ReportPost> GetAllPostReport();
        bool UpdatePostReport(ReportPost report_Post );
        bool DeletePostReport(int id);

    }
}
