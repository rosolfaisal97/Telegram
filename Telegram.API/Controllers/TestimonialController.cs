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
    [Authorize]
    public class TestimonialController : ControllerBase
    {
        
        private readonly ITestimonialcs TestimonialService;
        public TestimonialController(ITestimonialcs TestimonialService)
        {
            this.TestimonialService = TestimonialService;
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{T_id}")]
        public bool DeleteTestimonial(int T_id)
        {
            return TestimonialService.DeleteTestimonial(T_id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllTestimonial>), StatusCodes.Status200OK)]
        public List<GetAllTestimonial> GetAllTestimonial()
        {
            return TestimonialService.GetAllTestimonial();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GetAcceptTestimonialDto>), StatusCodes.Status200OK)]
        public List<GetAcceptTestimonialDto> GetAcceptTestimonial()
        {
            return TestimonialService.GetAcceptTestimonial();
        }
        // get
        [HttpGet("Single/{T_id}")]
        [ProducesResponseType(typeof(List<GetSingleTestimonial>), StatusCodes.Status200OK)]
        public List<GetSingleTestimonial> GetSingleTestimonial(int T_id)
        {
            return TestimonialService.GetSingleTestimonial(T_id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Testimonial InsertTestimonial(Testimonial Test)
        {
            return TestimonialService.InsertTestimonial(Test);
        }


        [HttpPut]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateTestimonial(Testimonial Test)
        {
            return TestimonialService.UpdateTestimonial(Test);
        }
    }
}
