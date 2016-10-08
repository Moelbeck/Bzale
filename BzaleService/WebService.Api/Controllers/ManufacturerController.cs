using depross.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Api.Controllers
{
    [RoutePrefix("api/Manufacturer")]
    public class ManufacturerController : ApiController
    {
        private ManufacturerWebService _manufacturerservice;

        public ManufacturerController()
        {
            _manufacturerservice = new ManufacturerWebService();
        }


        [HttpGet, Route("category/{id}")]
        public IHttpActionResult GetManufacturersInCategory(int id)
        {

            var manu = _manufacturerservice.GetManufacturersInCategory(id);
            if (manu != null)
            {
                return Ok(manu);
            }

            return NotFound();
        }
        [HttpGet]
        public IHttpActionResult GetManufacturer(int id)
        {

            var manu = _manufacturerservice.GetManuFacturer(id);
            if (manu != null)
            {
                return Ok(manu);
            }

            return NotFound();
        }
    }
}
