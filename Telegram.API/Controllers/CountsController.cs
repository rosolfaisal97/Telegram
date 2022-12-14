using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountsController : ControllerBase
    {

        private readonly ICountService countService ;
        public CountsController(ICountService countService)
        {
            this.countService = countService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("NumberOfChannels")]
        public List<NumberOfChannels> NumberOfChannels()
        {
            return countService.NumberOfChannels();
        }



        [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("NumberOfGroups")]
        public List<NumberOfGroups> NumberOfGroups()
        {
            return countService.NumberOfGroups();
        }



        [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("NumberOfUsers")]
        public List<NumberOfUsers> NumberOfUsers()
        {
            return countService.NumberOfUsers();
        }


    }
}
