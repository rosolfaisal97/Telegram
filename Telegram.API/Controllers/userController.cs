using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [ProducesResponseType(typeof(List<OwnerChannelName>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("OwnerChannel/{Cid}")]
        public List<OwnerChannelName> OwnerChannelName(int Cid)
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

        [HttpGet]
        [ProducesResponseType(typeof(List<ChannelPosts>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("ChannelPosts/{Cid}")]
        public List<ChannelPosts> ChannelPosts(int Cid)
        {
            return functionChannelUserService.GetChannelPosts(Cid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ChannelFiles>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("ChannelFiles/{Cid}")]
        public List<ChannelFiles> ChannelFiles(int Cid)
        {
            return functionChannelUserService.GetChannelFiles(Cid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountAdminsChannel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountAdminsChannel/{Cid}")]
        public List<CountAdminsChannel> CountAdminsChannel(int Cid)
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

        [HttpGet]
        [ProducesResponseType(typeof(List<CountChannelPosts>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountChannelPosts/{Cid}")]
        public List<CountChannelPosts> CountChannelPosts(int Cid)
        {
            return functionChannelUserService.GetCountChannelPosts(Cid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountChannelFiles>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountChannelFiles/{Cid}")]
        public List<CountChannelFiles> CountChannelFiles(int Cid)
        {
            return functionChannelUserService.GetCountChannelFiles(Cid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountCommentPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountCommentPost/{Pid}")]
        public List<CountCommentPost> CountCommentPost(int Pid)
        {
            return functionChannelUserService.GetCountCommentPost(Pid);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountLikePost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountLikePost/{Pid}")]
        public List<CountLikePost> CountLikePost(int Pid)
        {
            return functionChannelUserService.GetCountLikePost(Pid);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ChannelProfile>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("ChannelProfile/{Cid}")]
        public List<ChannelProfile> ChannelProfile(int Cid)
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
