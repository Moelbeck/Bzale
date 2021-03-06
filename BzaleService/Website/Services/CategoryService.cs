﻿using bzale.Service;
using depross.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace bzale.WebsiteService
{
    /// <summary>
    /// Contains service calls for Area and JobCategory
    /// </summary>
    public class CategoryService
    {

        private string accountURI = string.Format("{0}{1}", Konstanter.BASEURI, "Category/");
        private HttpBaseClient client;

        public CategoryService()
        {
            client = new HttpBaseClient(accountURI);

        }
        #region GET
        public async Task<List<CategoryDTO>> GetAllMainCategories(int page, int size =0)
        {
            if(size == 0) { size = Konstanter.PAGE_SIZE; }
            string uri = string.Format("allmain?page={0}&size={1}", page, Konstanter.PAGE_SIZE);
            var categories = await client.GetResponseObject<CategoryDTO, List<CategoryDTO>>(uri, eHttpMethodType.GET, null);
            return categories;
        }
        public async Task<CategoryDTO> GetCategory(int id)
        {
            string uri = string.Format("{0}", id);
            var categories = await client.GetResponseObject<CategoryDTO, CategoryDTO>(uri, eHttpMethodType.GET, null);
            return categories;
        }
        public async Task<List<CategoryDTO>> GetSubCategoriesForMain(int mainid)
        {
            string uri = string.Format("{0}/sub", mainid);
            var categories = await client.GetResponseObject<CategoryDTO, List<CategoryDTO>>(uri, eHttpMethodType.GET, null);
            return categories;
        }

        public async Task<List<CategoryDTO>> GetCategoriesBySearchString(string searchstring, int page)
        {
            string uri = string.Format("bysearch/{0}?page={1}&size={2}", searchstring,page,Konstanter.PAGE_SIZE);
            var categories = await client.GetResponseObject<CategoryDTO, List<CategoryDTO>>(uri, eHttpMethodType.GET, null);
            return categories;
        }
        public async Task<List<ProductTypeDTO>> GetProductTypesForCategory(int id, int page)
        {
            string uri = string.Format("sub/{0}/producttypes?page={1}&size={2}", id, page, Konstanter.PAGE_SIZE);
            var producttype = await client.GetResponseObject<ProductTypeDTO, List<ProductTypeDTO>>(uri, eHttpMethodType.GET, null);
            return producttype;
        }
        public async Task<ProductTypeDTO> GetProductTypeByID(int id)
        {

            string uri = string.Format("sub/{0}/ producttype", id);
            var producttype = await client.GetResponseObject<ProductTypeDTO, ProductTypeDTO>(uri, eHttpMethodType.GET, null);
            return producttype;
        }

        #endregion

        #region POST
        #endregion
        #region PUT

        #endregion

        #region DELETE
        #endregion

    }
}
