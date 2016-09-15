using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bzale.WebService;
using bzale.Repository.DatabaseContext;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bzale.Core.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    public class ManufacturerWebController : Controller
    {
        private ManufacturerWebService _manufacturerservice;

        public ManufacturerWebController(IProductRepository prodRepo,IManufacturerRepository manuRepo, ICategoryRepository catRepo)
        {
            _manufacturerservice = new ManufacturerWebService(prodRepo,manuRepo,catRepo);
        }


        [HttpGet]
        [Route("category/{id}")]
        public IActionResult GetManufacturersInCategory(int id)
        {

            var manu = _manufacturerservice.GetManufacturersInCategory(id);
            if (manu != null)
            {
                return Ok(manu);
            }

            return NotFound("Ingen fabrikanter blev ikke fundet");
        }
        [HttpGet]
        public IActionResult GetManufacturer(int id)
        {

            var manu = _manufacturerservice.GetManuFacturer(id);
            if (manu != null)
            {
                return Ok(manu);
            }

            return NotFound("Ingen fabrikanter blev ikke fundet");
        }
        [HttpGet]
        [Route("{id}/products/")]
        public IActionResult GetProductsByManufacturerID(int id)
        {

            var products = _manufacturerservice.GetProductsByManufacturer(id);
            if (products != null)
            {
                return Ok(products);
            }

            return NotFound("Ingen produkter blev ikke fundet");
        }

        [HttpGet]
        [Route("product/{id}")]
        public IActionResult GetProductByID(int id)
        {

            var products = _manufacturerservice.GetProductByID(id);
            if (products != null)
            {
                return Ok(products);
            }

            return NotFound("Ingen produkter blev ikke fundet");
        }

    }
}