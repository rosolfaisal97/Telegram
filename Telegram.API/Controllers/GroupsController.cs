using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupsController : Controller
    {
        private readonly IGroupsService groupsService;
        public GroupsController(IGroupsService _groupsService)
        {
            groupsService = _groupsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Groups>), StatusCodes.Status200OK)]
        public List<Groups> GetAllAdminGroup()
        {
            return groupsService.GetAllGroups();
        }


        [HttpPost]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool createadmingroup([FromBody] Groups groups)
        {
            return groupsService.CreateGroups(groups);
        }



        [HttpDelete("delete/{id}")]
        public bool DeleteAdminGroup(int id)
        {
            return groupsService.DeleteGroups(id);
        }


       

        [HttpPut]
        public bool UpdateAdminGroup([FromBody] Groups groups)
        {
            return groupsService.UpdateGroups(groups);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<GroupsInfoDto>), StatusCodes.Status200OK)]
        [Route("GroupInfo")]
        public List<GroupsInfoDto> GetGroupsInfo()
        {
            return groupsService.GetGroupsInfo();
        }



        [HttpGet]
        [ProducesResponseType(typeof(List<CountUserAdminForgroupDto>), StatusCodes.Status200OK)]
        [Route("CountUserAdminForgroupDto")]
        public List<CountUserAdminForgroupDto> CountUserAdminForgroup()
        {
            return groupsService.CountUserAdminForgroup();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountMemberEachgroupDto>), StatusCodes.Status200OK)]
        [Route("CountMemberEachgroup")]
        public List<CountMemberEachgroupDto> CountMemberEachgroup()
        {
            return groupsService.CountMemberEachgroup();
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<GetNameAdminGroupDto>), StatusCodes.Status200OK)]
        [Route("CountMemberEachgrop/{getNameAdminGroupDto}")]
        public List<GroupAdmin> GetNameAdminGroup(GetNameAdminGroupDto getNameAdminGroupDto)
        {
            return groupsService.GetNameAdminGroup(getNameAdminGroupDto);
        }


        [HttpGet]
        [Route("MediaEachgroup/{getMediaEachgroupDto}")]
        [ProducesResponseType(typeof(List<GetMediaEachgroupDto>), StatusCodes.Status200OK)]
        public List<MediaGroup> GetMediaEachgroup(GetMediaEachgroupDto getMediaEachgroupDto)
        {
            return groupsService.GetMediaEachgroup(getMediaEachgroupDto);
        }

        [HttpGet]
        [Route("CountMemberEachgroup/{countMediaEachgroupDto}")]
        public List<MediaGroup> CountMediaEachgroup(CountMediaEachgroupDto countMediaEachgroupDto)
        {
            return groupsService.CountMediaEachgroup(countMediaEachgroupDto);
        }

        [HttpGet]
        [Route("AdminsGroupName/{adminsGroupNameDto}")]
        public List<GroupAdmin> AdminsGroupName(AdminsGroupNameDto adminsGroupNameDto)
        {
            return groupsService.AdminsGroupName(adminsGroupNameDto);
        }


        [HttpGet]
        [Route("OwnergrouplName/{ownergrouplNameDto}")]
        public List<Groups> OwnergrouplName(OwnergrouplNameDto ownergrouplNameDto)
        {
            return groupsService.OwnergrouplName(ownergrouplNameDto);
        }

        [HttpGet]
        [Route("groupMember/{groupMemberDto}")]
        public List<GroupMember> groupMember(GroupMemberDto groupMemberDto)
        {
            return groupsService.groupMember(groupMemberDto);
        }

    }
}
