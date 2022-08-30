using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class TestimonialController : Controller
    {
        
        private readonly ITestimonialcs TestimonialService;
        public TestimonialController(ITestimonialcs TestimonialService)
        {
            this.TestimonialService = TestimonialService;
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete")]
        public bool DeleteTestimonial([FromBody] Testimonial Test)
        {
            return TestimonialService.DeleteTestimonial(Test);
        }

        [HttpGet]
      //  [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        public List<Testimonial> GetAllTestimonial()
        {
            return TestimonialService.GetAllTestimonial();
        }
        [HttpGet]
       // [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<GetAcceptTestimonialDto>), StatusCodes.Status200OK)]
        public List<GetAcceptTestimonialDto> GetAcceptTestimonial()
        {
            return TestimonialService.GetAcceptTestimonial();
        }
        
        [HttpPost("Single")]
//[Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<GetSingleTestimonial>), StatusCodes.Status200OK)]
        public List<GetSingleTestimonial> GetSingleTestimonial([FromBody] Testimonial Test)
        {
            return TestimonialService.GetSingleTestimonial(Test);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Testimonial InsertTestimonial([FromBody] Testimonial Test)
        {
            return TestimonialService.InsertTestimonial(Test);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateTestimonial([FromBody] Testimonial Test)
        {
            return TestimonialService.UpdateTestimonial(Test);
        }
    }
}
