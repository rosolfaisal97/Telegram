using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class TestimonialService: ITestimonialcs
    {



        private readonly ITestimonial TestimonialRepo;

        public TestimonialService(ITestimonial TestimonialRepo)
        {
            this.TestimonialRepo = TestimonialRepo;
        }

        public bool DeleteTestimonial(Testimonial Test)
        {
            return TestimonialRepo.DeleteTestimonial(Test);
        }

        public List<Testimonial> GetAllTestimonial()
        {
            return TestimonialRepo.GetAllTestimonial();
        }
        public List<GetAcceptTestimonialDto> GetAcceptTestimonial()
        {
            return TestimonialRepo.GetAcceptTestimonial();
        }
        public List<GetSingleTestimonial> GetSingleTestimonial(Testimonial Test)
        {
            return TestimonialRepo.GetSingleTestimonial(Test);
        }

            public Testimonial InsertTestimonial(Testimonial Test)
        {
            return TestimonialRepo.InsertTestimonial(Test);
        }

        public bool UpdateTestimonial(Testimonial Test)
        {
            return TestimonialRepo.UpdateTestimonial(Test);
        }
    }
}
