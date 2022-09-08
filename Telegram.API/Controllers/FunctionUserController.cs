using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class FunctionUserController : Controller
    {

        private readonly IFunctionChannelUserService functionChannelUserService;
        public FunctionUserController(IFunctionChannelUserService functionChannelUserService)
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
        [ProducesResponseType(typeof(List<ChannelsSubscribed>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("ChannelsSubscribed/{Cid}")]
        public List<ChannelsSubscribed> ChannelsSubscribed(int Cid)
        {
            return functionChannelUserService.ChannelsSubscribed(Cid);
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



        //CountAdminsChannel
        [HttpGet]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountAdminsChannel/{Cid}")]
        public int CountAdminsChannel(int Cid)
        {
            return functionChannelUserService.GetAdminsChannelName(Cid).Count;
        }


        //CountChannelMember
        [HttpGet]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountChannelMember/{Cid}")]
        public int CountChannelMember(int Cid)
        {
            return functionChannelUserService.GetChannelMember(Cid).Count;
        }

        //CountChannelPosts
        [HttpGet]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountChannelPosts/{Cid}")]
        public int CountChannelPosts(int Cid)
        {
            return functionChannelUserService.GetChannelPosts(Cid).Count;
        }
        //CountChannelFiles
        [HttpGet]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountChannelFiles/{Cid}")]
        public int CountChannelFiles(int Cid)
        {
            return functionChannelUserService.GetChannelFiles(Cid).Count;
        }


        ///CountCommentPost
        [HttpGet]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountCommentPost/{Pid}")]
        public int CountCommentPost(int Pid)
        {
            return functionChannelUserService.GetCommentPost(Pid).Count;
        }
        //CountLikePost
        [HttpGet]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CountLikePost/{Pid}")]

        public int CountLikePost(int Pid)
        {
            return functionChannelUserService.GetLikePost(Pid).Count;
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

        //add id channel
        [HttpPost]
        [ProducesResponseType(typeof(List<FilterChannelByMember>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("FilterChannelByMember")]
        public List<FilterChannelByMember> FilterChannelByMember([FromBody] FilterChannelByMember filterChannelByMember)
        {
            return functionChannelUserService.GetFilterChannelByMember(filterChannelByMember);
        }


        //add id channel
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
