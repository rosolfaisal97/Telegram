using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class UserRepoertService : IUserRepoertService
    {
        private readonly IUserRepoertRepository _repoertRepository;
        public UserRepoertService(IUserRepoertRepository repoertRepository)
        {
            _repoertRepository = repoertRepository;
        }

        public bool Delete(UserReportFormDTO userReport)
        {
            return _repoertRepository.Delete(userReport);
        }

        public List<UserReportFormDTO> FilterByType(UserReportFormDTO form)
        {
            return _repoertRepository.FilterByType(form);
        }

        public List<UserReportDTO> GetAllUsersReports(int limit = 0, int count = 100)
        {
            return _repoertRepository.GetAllUsersReports(limit, count);
        }

        public UserReportDetailsDTO GetUserReportDetials(int userId)
        {
            return _repoertRepository.GetUserReportDetials(userId);
        }

        public List<UserReportDetailsDTO> GetUserReports(int userToId)
        {
            return _repoertRepository.GetUserReports(userToId);
        }

        public bool Insert(UserReportFormDTO userReport)
        {
            return _repoertRepository.Insert(userReport);
        }

        public bool Update(UserReportFormDTO userReport)
        {
            return _repoertRepository.Update(userReport);
        }

        public int UserReportCount(int UserToId)
        {
            return _repoertRepository.UserReportCount(UserToId);
        }
    }

}
