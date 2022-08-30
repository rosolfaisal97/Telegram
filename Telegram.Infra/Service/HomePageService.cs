using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class HomePageService : IHomePageService
    {
        private readonly IHomePageRepository homePageRepository ;

        public HomePageService(IHomePageRepository homePageRepository)
        {
            this.homePageRepository = homePageRepository;
        }
        public bool DeleteContactUs(int id)
        {
            return homePageRepository.DeleteContactUs(id);
        }

        public List<AboutUs> GetAboutUsInfo()
        {
            return homePageRepository.GetAboutUsInfo();
        }

        public List<ContactUs> GetAllContactUs()
        {
            return homePageRepository.GetAllContactUs();
        }

        public List<Home> GetHomeInfo()
        {
           return homePageRepository.GetHomeInfo();
        }

        public bool InsertContactUs(ContactUs contactUs)
        {
           return homePageRepository.InsertContactUs(contactUs);
        }

        public bool UpdateAboutUsInfo(AboutUs aboutUs)
        {
            return homePageRepository.UpdateAboutUsInfo(aboutUs);
        }

        public bool UpdateHomeInfo(Home home)
        {
            return homePageRepository.UpdateHomeInfo(home);
        }
    }
}
