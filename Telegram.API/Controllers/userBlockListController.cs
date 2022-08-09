﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class userBlockListController : ControllerBase
    {
         
        private readonly IuserBlockListService userBlockListService;
        public userBlockListController(IuserBlockListService userBlockListService)
        {
            this.userBlockListService = userBlockListService;
        }
        [HttpDelete("delete/UB_id")]
        public bool DeleteUserBlock(int? UB_id)
        {
            return userBlockListService.DeleteUserBlock(UB_id);
        }

        [HttpGet]
        public List<UserBlockList> GetAllUserBlock()
        {
            return userBlockListService.GetAllUserBlock();
        }

        [HttpPost]
        public UserBlockList InsertUserBlock([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.InsertUserBlock(userBlock);
        }

        [HttpPost("MY_block")]
        public List<My_block_ListDTO> My_block_List([FromBody] My_block_ListDTO my_Block)
        {
            return userBlockListService.My_block_List(my_Block);
        }
        [HttpPut]
        public bool UpdateUserBlock([FromBody] UserBlockList userBlock)
        {
            return userBlockListService.UpdateUserBlock(userBlock);
        }
    }
}
