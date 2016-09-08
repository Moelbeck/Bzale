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
        private CategoryWebService _categoryService;

        public ManufacturerWebController(BzaleDatabaseContext context)
        {
            _categoryService = new CategoryWebService(context);
        }


        [HttpGet]
        [Route("category/{id}")]
        public IActionResult GetManufacturersInCategory(int id)
        {

            var manu = _categoryService.GetManufacturersInCategory(id);
            if (manu != null)
            {
                return Ok(manu);
            }

            return NotFound("Ingen fabrikanter blev ikke fundet");
        }
        [HttpGet]
        public IActionResult GetManufacturer(int id)
        {

            var manu = _categoryService.GetManuFacturer(id);
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

            var products = _categoryService.GetProductsByManufacturer(id);
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

            var products = _categoryService.GetProductByID(id);
            if (products != null)
            {
                return Ok(products);
            }

            return NotFound("Ingen produkter blev ikke fundet");
        }

    }
}