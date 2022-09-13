using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService subscriptionService ;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            this.subscriptionService = subscriptionService;
        }

        [HttpGet]
        // [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<ProfitsAndLosses>), StatusCodes.Status200OK)]
        public List<ProfitsAndLosses> ProfitsAndLosses()
        {
            return subscriptionService.GetProfitsAndLosses();
        }


        [HttpGet]
        // [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<GetAllSubscription>), StatusCodes.Status200OK)]
        public List<GetAllSubscription> GetAllSubscription()
        {
            return subscriptionService.GetAllSubscription();
        }


        [HttpGet]
        // [Authorize(Roles = "Admin")]
        [Route("{uId}")]
        [ProducesResponseType(typeof(List<GetUserSubscription>), StatusCodes.Status200OK)]
        public List<GetUserSubscription> GetUserSubscription( int uId)
        {
            return subscriptionService.GetUserSubscription(uId);
        }

        [HttpPost]
        // [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(Subscription), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool InsertSubscription([FromBody] Subscription subscription )
        {
            return subscriptionService.InsertSubscription(subscription);
        }

       
        [HttpDelete]
        // [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<Services>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Route("delete")]
        public bool DeleteSubscription([FromBody] Subscription subscription)
        {
            return subscriptionService.DeleteSubscription(subscription);
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Subscription>), StatusCodes.Status200OK)]
        public List<Subscription> AllSubscription()
        {
            return subscriptionService.AllSubscribe();
        }
    }
}
