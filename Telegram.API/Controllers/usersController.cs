using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IFunctionChannelUserService functionChannelUserService;
        public UserController(IFunctionChannelUserService functionChannelUserService)
        {
            this.functionChannelUserService = functionChannelUserService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AdminsChannelName>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("AdminsChannel/{Cid}")]
        public List<AdminsChannelName> AdminsChannelName(int Cid)
        {
            return functionChannelUserService.GetAdminsChannelName(Cid);
        }

 
        [HttpDelete("delete/{U_id}")]
        public bool DeleteUsers(int U_id)
 
        {
            return functionChannelUserService.GetOwnerChannelName(Cid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MemberChannel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("ChannelMember/{Cid}")]
        public List<MemberChannel> ChannelMember(int Cid)
        {
            return functionChannelUserService.GetChannelMember(Cid);
        }
 
        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public User InsertUsers([FromBody]User uss)
         {
            return functionChannelUserService.GetCountAdminsChannel(Cid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountChannelMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountChannelMember/{Cid}")]
        public List<CountChannelMember> CountChannelMember(int Cid)
        {
            return functionChannelUserService.GetCountChannelMember(Cid);
        }

 
        [HttpPost("NumberUserByGender/{U_gender}")]
        public List<NumberOfUserByGenderdto> NumberOfUserByGender(string U_gender)
        {
            return usersService.NumberOfUserByGender(U_gender);
 
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountChannelFiles>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountChannelFiles/{Cid}")]
        public List<CountChannelFiles> CountChannelFiles(int Cid)
        {
            return functionChannelUserService.GetCountChannelFiles(Cid);
        }

 
        [HttpPost("SarchUserInfo/{sarch}")]
            public List<SearchUserInfo> SarchUserInfo(string sarch)
        {
            return usersService.SarchUserInfo(sarch);
        }

        [HttpPost("SearchDate/{dateto}/{datefrom}")]
        
        public List<SearchButweenTwoDatedto> SearchButweenTwoDate(DateTime dateto, DateTime datefrom)
        {
            return usersService.SearchButweenTwoDate(dateto, datefrom);
        }

        [HttpPut("UpdateProfile")]
        public bool UpdateProfileUser([FromBody] UpdateProfileUserDTO Upd)
         {
            return functionChannelUserService.GetChannelProfile(Cid);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<CommentPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CommentPost/{Pid}")]
        public List<CommentPost> CommentPost(int Pid)
        {
            return functionChannelUserService.GetCommentPost(Pid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<LikePost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("LikePost/{Pid}")]
        public List<LikePost> LikePost(int Pid)
        {
            return functionChannelUserService.GetLikePost(Pid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FilesPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("FilesPost/{Pid}")]
        public List<FilesPost> FilesPost(int Pid)
        {
            return functionChannelUserService.GetFilesPost(Pid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PostReprortInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("PostReprortInfo/{Pid}")]
        public List<PostReprortInfo> PostReprortInfo(int Pid)
        {
            return functionChannelUserService.GetPostReprortInfo(Pid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CheckReprort>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CheckReprort/{Pid}")]
        public List<CheckReprort> CheckReprort(int Pid)
        {
            return functionChannelUserService.GetCheckReprort(Pid);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<FilterChannelByMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("FilterChannelByMember")]
        public List<FilterChannelByMember> FilterChannelByMember([FromBody] FilterChannelByMember filterChannelByMember)
        {
            return functionChannelUserService.GetFilterChannelByMember(filterChannelByMember);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<FilterChannelPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("FilterChannelPost")]
        public List<FilterChannelPost> FilterChannelPost([FromBody] FilterChannelPost filterChannelPost)
        {
            return functionChannelUserService.GetFilterChannelPost(filterChannelPost);
        }

    }
}
