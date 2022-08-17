using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface ITestimonial
    {
        public List<GetAllTestimonial> GetAllTestimonial();
        public Testimonial InsertTestimonial(Testimonial Test);
        public bool UpdateTestimonial(Testimonial Test);
        public bool DeleteTestimonial(int T_id);
        public List<GetAcceptTestimonialDto> GetAcceptTestimonial();
        public List<GetSingleTestimonial> GetSingleTestimonial(int T_id);

    }
}
