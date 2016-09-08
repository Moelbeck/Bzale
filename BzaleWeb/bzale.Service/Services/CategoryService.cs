using bzale.Service;
using bzale.Service.Enum;
using bzale.ViewModel;
using bzale.Web.Services.HttpBaseClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Web2.Service
{
    /// <summary>
    /// Contains service calls for Area and JobCategory
    /// </summary>
    public class CategoryService
    {

        private string accountURI = string.Format("{0}{1}", Konstanter.BASEURI, "CategoryWeb/");
        private HttpBaseClient client;

        public CategoryService()
        {
            client = new HttpBaseClient(accountURI);

        }
        #region GET
        public async Task<List<CategoryDTO>> GetAllMainCategories(int page)
        {
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

        #endregion

        #region POST
        #endregion
        #region PUT

        #endregion

        #region DELETE
        #endregion

    }
}
