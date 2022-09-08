using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface IUserRepoertService
    {
        bool Insert(UserReportFormDTO userReport);
        bool Update(UserReportFormDTO userReport);
        bool Delete(UserReportFormDTO userReport);
        List<UserReportDTO> GetAllUsersReports(int limit = 0, int count = 100);
        List<UserReportDetailsDTO> GetUserReports(int userToId);
        List<UserReportFormDTO> FilterByType(UserReportFormDTO form);
        int UserReportCount(int UserToId);

        UserReportDetailsDTO GetUserReportDetials(int userId);

    }
}
