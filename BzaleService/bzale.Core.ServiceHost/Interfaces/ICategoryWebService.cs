using bzale.Common;
using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzale.WebService
{
    public interface ICategoryWebService
    {

        #region Categories
        List<CategoryDTO> GetMainCategories(int page, int size);
 
        CategoryDTO GetCategory(int id);

        List<CategoryDTO> GetSubCategoriesForMain(int id);

 
        List<CategoryDTO> GetCategoriesBySearchString(string searchstring, int page, int size, int userid);
        #endregion

        #region Manufacturer

        #endregion

        void CreateMainCategory(CategoryDTO viewmodel);
        void CreateSubCategory(int mainid,CategoryDTO viewmodel);

    }
}
