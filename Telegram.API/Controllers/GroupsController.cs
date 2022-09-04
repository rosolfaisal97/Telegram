﻿using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class GroupsController : Controller
    {
        private readonly IGroupsService groupsService;
        public GroupsController(IGroupsService _groupsService)
        {
            groupsService = _groupsService;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Groups>), StatusCodes.Status200OK)]
        public List<Groups> GetAllAdminGroup()
        {
            return groupsService.GetAllGroups();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Groups), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool createadmingroup([FromBody] Groups groups)
        {
            return groupsService.CreateGroups(groups);
        }



        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public bool DeleteAdminGroup([FromBody] Groups groups)
        {
            return groupsService.DeleteGroups(groups);
        }


       

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public bool UpdateAdminGroup([FromBody] Groups groups)
        {
            return groupsService.UpdateGroups(groups);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<GroupsInfoDto>), StatusCodes.Status200OK)]
        [Route("GroupInfo")]
        public List<GroupsInfoDto> GetGroupsInfo()
        {
            return groupsService.GetGroupsInfo();
        }



        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<CountUserAdminForgroupDto>), StatusCodes.Status200OK)]
        [Route("CountUserAdminForgroupDto")]
        public List<CountUserAdminForgroupDto> CountUserAdminForgroup()
        {
            return groupsService.CountUserAdminForgroup();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<CountMemberEachgroupDto>), StatusCodes.Status200OK)]
        [Route("CountMemberEachgroup")]
        public List<CountMemberEachgroupDto> CountMemberEachgroup()
        {
            return groupsService.CountMemberEachgroup();
        }


        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<GetNameAdminGroupDto>), StatusCodes.Status200OK)]
        [Route("CountMemberEachgrop/{getNameAdminGroupDto}")]
        public List<GroupAdmin> GetNameAdminGroup(GetNameAdminGroupDto getNameAdminGroupDto)
        {
            return groupsService.GetNameAdminGroup(getNameAdminGroupDto);
        }


        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [Route("MediaEachgroup/{getMediaEachgroupDto}")]
        [ProducesResponseType(typeof(List<GetMediaEachgroupDto>), StatusCodes.Status200OK)]
        public List<MediaGroup> GetMediaEachgroup(GetMediaEachgroupDto getMediaEachgroupDto)
        {
            return groupsService.GetMediaEachgroup(getMediaEachgroupDto);
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [Route("CountMemberEachgroup/{countMediaEachgroupDto}")]
        public List<MediaGroup> CountMediaEachgroup(CountMediaEachgroupDto countMediaEachgroupDto)
        {
            return groupsService.CountMediaEachgroup(countMediaEachgroupDto);
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [Route("AdminsGroupName/{adminsGroupNameDto}")]
        public List<GroupAdmin> AdminsGroupName(AdminsGroupNameDto adminsGroupNameDto)
        {
            return groupsService.AdminsGroupName(adminsGroupNameDto);
        }


        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [Route("OwnergrouplName/{ownergrouplNameDto}")]
        public List<Groups> OwnergrouplName(OwnergrouplNameDto ownergrouplNameDto)
        {
            return groupsService.OwnergrouplName(ownergrouplNameDto);
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [Route("groupMember/{groupMemberDto}")]
        public List<GroupMember> groupMember(GroupMemberDto groupMemberDto)
        {
            return groupsService.groupMember(groupMemberDto);
        }

    }
}
