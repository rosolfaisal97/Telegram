using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;

namespace Telegram.Core.Service
{
    public interface IHomePageService
    {
        //Home
        bool UpdateHomeInfo(Home home);
        List<Home> GetHomeInfo();

        //AboutUs
        bool UpdateAboutUsInfo(AboutUs aboutUs);
        List<AboutUs> GetAboutUsInfo();

        //ContactUs
        bool InsertContactUs(ContactUs contactUs);
        bool DeleteContactUs(int id);
        List<ContactUs> GetAllContactUs();

    }
}
