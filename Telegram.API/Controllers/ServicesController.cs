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
    public class ServicesController : Controller
    {
        private readonly IServicesService servicesService ;
        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [Route("UploadImageServices")]
        public Services UploadImageServices()
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
                var fullPath = Path.Combine("F:\\Telegram\\Telegram\\src\\assets", attachmentFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Services Item = new Services();
                Item.Image = fileName;
                return Item;
            }
            catch (Exception)
            {
                return null;
            }

        }
        [HttpGet]
       // [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Services>), StatusCodes.Status200OK)]
        public List<Services> GetAllSERVICES()
        {
            return servicesService.GetAllSERVICES();
        }

        [HttpPost]
       // [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(Services), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateService")]
        public bool CreateService([FromBody] Services services)
        {
            return servicesService.CreateSERVICES(services);
        }

        [HttpPut]
       // [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(Services), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateService")]
        public bool UpdateService([FromBody] Services services)
        {
            return servicesService.UpdateSERVICES(services);
        }

        [HttpDelete]
       // [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(List<Services>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("DeleteService/{id}")]
        public bool DeleteService(int id)
        {
           return servicesService.DeleteSERVICES( id);
        }

    }
}
