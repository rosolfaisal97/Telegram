using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserRepoertController : Controller
    {
        private readonly IUserRepoertService _repoertService;
        public UserRepoertController(IUserRepoertService repoertService)
        {
            _repoertService = repoertService;
        }

        [HttpPost]
        public bool Delete([FromBody] UserReportFormDTO userReport)
        {
            return _repoertService.Delete(userReport);
        }

        [HttpPost]
        public List<UserReportFormDTO> FilterByType([FromBody] UserReportFormDTO form)
        {
            return _repoertService.FilterByType(form);
        }
        [HttpGet]
        [Route("{limit}/{count}")]
        public List<UserReportDTO> GetAllUsersReports(int limit = 0, int count = 100)
        {
            return _repoertService.GetAllUsersReports(limit, count);
        }

        [HttpGet]
        [Route("{userId}")]
        public UserReportDetailsDTO GetUserReportDetials(int userId)
        {
            return _repoertService.GetUserReportDetials(userId);
        }
        [HttpGet]
        [Route("{userToId}")]
        public List<UserReportDetailsDTO> GetUserReports(int userToId)
        {
            return _repoertService.GetUserReports(userToId);
        }

        [HttpPost]
        public bool Insert([FromBody] UserReportFormDTO userReport)
        {
            return _repoertService.Insert(userReport);
        }

        [HttpPost]
        public bool Update([FromBody] UserReportFormDTO userReport)
        {
            return _repoertService.Update(userReport);
        }
        [HttpGet]
        [Route("UserToId")]
        public int UserReportCount(int UserToId)
        {
            return _repoertService.UserReportCount(UserToId);
        }
    }








}
