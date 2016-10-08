using depross.ViewModel;
using depross.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Api.Controllers
{

    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private CategoryWebService _categoryService;

        public CategoryController()
        {

            _categoryService = new CategoryWebService();
        }

        [HttpGet, Route("allmain")]
        
        public IHttpActionResult GetAllCategories(int page, int size)
        {

            var categories = _categoryService.GetMainCategories(page, size);
            if (categories.Any())
            {
                return Ok(categories);
            }
            return NotFound();
        }
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var category = _categoryService.GetMainCategory(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }
        [HttpGet, Route("{mainid}/sub")]
        public IHttpActionResult GetSubCategoriesForMain(int mainid)
        {
            var sub = _categoryService.GetSubCategoriesForMain(mainid);
            if (sub != null)
            {
                return Ok(sub);
            }
            return NotFound();
        }
        [HttpGet, Route("bysearch/{searchString}")]       
        public IHttpActionResult GetCategoriesBySearchString(string searchString, int page, int size, int userid)
        {
            if (ModelState.IsValid)
            {
                var bysearch = _categoryService.GetMainCategoriesBySearchString(searchString, page, size, userid);
                if (bysearch != null)
                {
                    return Ok(bysearch);
                }

                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpPost, Route("create")]
        
        public IHttpActionResult CreateMainCategory([FromBody]CategoryDTO viewmodel)
        {
            _categoryService.CreateMainCategory(viewmodel);
            return Ok(true);
        }
        [HttpPost, Route("{main}/createsub")]
        public IHttpActionResult CreateSubCategory(int main, [FromBody]CategoryDTO viewmodel)
        {
            _categoryService.CreateSubCategory(main, viewmodel);
            return Ok(true);
        }

        #region ProductTypes
        [HttpGet, Route("sub/{subcategory}/producttypes")]
        public IHttpActionResult GetProductTypesForSubCategory(int subcategory, int page, int size)
        {
            var producttypes = _categoryService.GetProductTypesForSubCategory(subcategory, page, size);
            if (producttypes != null)
            {
                return Ok(producttypes);
            }
            return NotFound();
        }
        [HttpGet, Route("sub/{id}/producttype")]
        public IHttpActionResult GetProductType(int id)
        {
            var producttypes = _categoryService.GetProdyctType(id);
            if (producttypes != null)
            {
                return Ok(producttypes);
            }
            return NotFound();
        }
        #endregion
    }
}
