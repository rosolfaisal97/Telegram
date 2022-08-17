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

        public bool DeleteTestimonial(int T_id)
        {
            return TestimonialRepo.DeleteTestimonial(T_id);
        }

        public List<GetAllTestimonial> GetAllTestimonial()
        {
            return TestimonialRepo.GetAllTestimonial();
        }
        public List<GetAcceptTestimonialDto> GetAcceptTestimonial()
        {
            return TestimonialRepo.GetAcceptTestimonial();
        }
        public List<GetSingleTestimonial> GetSingleTestimonial(int T_id)
        {
            return TestimonialRepo.GetSingleTestimonial(T_id);
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
