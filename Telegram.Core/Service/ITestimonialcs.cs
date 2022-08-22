using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface ITestimonialcs
    {
        public List<GetAllTestimonial> GetAllTestimonial();
        public Testimonial InsertTestimonial(Testimonial Test);
        public bool UpdateTestimonial(Testimonial Test);
        public bool DeleteTestimonial(Testimonial Test);
        public List<GetAcceptTestimonialDto> GetAcceptTestimonial();
        public List<GetSingleTestimonial> GetSingleTestimonial(Testimonial Test);


    }
}
