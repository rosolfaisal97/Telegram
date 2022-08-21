using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GroupLinkController : ControllerBase
    {
        private readonly IGroupLinkService groupLinkService;
        public GroupLinkController(IGroupLinkService _groupLinkService)
        {
            groupLinkService = _groupLinkService;
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<GroupLink>), StatusCodes.Status200OK)]
        public List<GroupLink> GetAllLinkGroup()
        {
            return groupLinkService.GetAllLinkGroup();
        }


        [HttpPost]
        [ProducesResponseType(typeof(GroupLink), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "User")]
        public bool CreateLinkGroup([FromBody] GroupLink groupLink)
        {
            return groupLinkService.CreateLinkGroup(groupLink);
        }



        [HttpDelete("delete")]
        [Authorize(Roles = "User")]
        public bool DeleteLinkGroup([FromBody] GroupLink groupLink)
        {
            return groupLinkService.DeleteLinkGroup(groupLink);
        }



        [HttpPut]
        [Authorize(Roles = "User")]
        public bool UpdateLinkGroup([FromBody] GroupLink groupLink)
        {
            return groupLinkService.UpdateLinkGroup(groupLink);
        }







    }
}
