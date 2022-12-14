using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Core.Data;
using Telegram.Core.Service;

namespace Telegram.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
     public class HomePageController : Controller
    {

        private readonly IHomePageService homePageService ;
        public HomePageController(IHomePageService homePageService)
        {
            this.homePageService = homePageService;
        }


        [HttpGet]
         [ProducesResponseType(typeof(List<AboutUs>), StatusCodes.Status200OK)]
        [Route("AboutUs")]
        public List<AboutUs> GetAboutUsInfo()
        {
            return homePageService.GetAboutUsInfo();
        }

        [HttpGet]
         [ProducesResponseType(typeof(List<ContactUs>), StatusCodes.Status200OK)]
        [Route("ContactUs")]
        public List<ContactUs> GetAllContactUs()
        {
            return homePageService.GetAllContactUs();
        }
        [HttpGet]
         [ProducesResponseType(typeof(List<Home>), StatusCodes.Status200OK)]
        [Route("Home")]
        public List<Home> GetHomeInfo()
        {
            return homePageService.GetHomeInfo();
        }

        [HttpDelete]
         [ProducesResponseType(typeof(List<ContactUs>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("deleteContactUs/{id}")]
        public bool deleteContactUs(int id)
        {
            return homePageService.DeleteContactUs(id);
        }



        [HttpPost]
         [ProducesResponseType(typeof(List<ContactUs>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("InsertContactUs")]
        public bool InsertContactUs([FromBody] ContactUs contactUs)
        {
            return homePageService.InsertContactUs(contactUs);
        }

        [HttpPost]
         [Route("UploadImageAboutUs")]
        public AboutUs UploadImageAboutUs()
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    fileContent = stream.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var attachmentFileName = $"{fileName}{Path.GetExtension(file.Name)}";
                var fullPath = Path.Combine(@"D:\My Files\Telegram Project\front-end-3\Telegram\src\assets\img", attachmentFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                AboutUs Item = new AboutUs();
                Item.img = fileName;
                return Item;
            }
            catch (Exception)
            {
                return null;
            }

        }
        [HttpPost]
         [Route("UploadImageHome")]

        public Home UploadHome()
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    fileContent = stream.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var attachmentFileName = $"{fileName}{Path.GetExtension(file.Name)}";
                var fullPath = Path.Combine(@"D:\My Files\Telegram Project\front-end-3\Telegram\src\assets\img", attachmentFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home Item = new Home();
                Item.img = fileName;
                return Item;
            }
            catch (Exception)
            {
                return null;
            }

        }
        [HttpPut]
         [ProducesResponseType(typeof(List<AboutUs>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateAboutUs")]
        public bool UpdateAboutUsInfo([FromBody] AboutUs aboutUs )
        {
            return homePageService.UpdateAboutUsInfo(aboutUs);
        }

        [HttpPut]
         [ProducesResponseType(typeof(List<Home>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateHome")]
        public bool UpdateHomeInfo([FromBody] Home home )
        {
            return homePageService.UpdateHomeInfo(home);
        }
    }
}
