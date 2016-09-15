using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bzale.ViewModel;
using bzale.WebService;
using bzale.Common;
using bzale.Repository.DatabaseContext;
using AutoMapper;
using bzale.Model;

namespace bzale.Core.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [RequireHttps]
    public class CategoryWebController : Controller
    {
        private CategoryWebService _categoryService;

        public CategoryWebController(ICategoryRepository catrepo, ISubCategoryRepository subrepo)
        {
            
                _categoryService = new CategoryWebService(catrepo,subrepo);
        }

        [HttpGet]
        [Route("allmain")]
        public IActionResult GetAllCategories(int page,int size)
        {

                var categories = _categoryService.GetMainCategories(page,size);
                if (categories.Any())
                {
                    return Ok(categories);
                }
                return NotFound(string.Format("Ingen kategorier fundet for side {0}", page));
        }
        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound("Kategorien blev ikke fundet");
        }
        [HttpGet]
        [Route("{mainid}/sub")]
        public IActionResult GetSubCategoriesForMain(int mainid)
        {
            var sub = _categoryService.GetSubCategoriesForMain(mainid);
            if (sub != null)
            {
                return Ok(sub);
            }
            return NotFound("Ingen subkategorier er fundet");
        }
        [HttpGet]
        [Route("bysearch/{searchString}")]
        public IActionResult GetCategoriesBySearchString(string searchString, int page, int size, int userid)
        {
            if (ModelState.IsValid)
            {
                var bysearch = _categoryService.GetCategoriesBySearchString(searchString,page,size,userid);
                if (bysearch != null)
                {
                    return Ok(bysearch);
                }

                return NotFound("Ingen kategorier blev ikke fundet ud fra søgning");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateMainCategory([FromBody]CategoryDTO viewmodel)
        {
            _categoryService.CreateMainCategory(viewmodel);
            return Ok(true);
        }
        [HttpPost]

        [Route("{main}/createsub")]
        public ActionResult CreateSubCategory(int main, [FromBody]CategoryDTO viewmodel)
        {
            _categoryService.CreateSubCategory(main, viewmodel);
            return Ok(true);
        }
    }
}
