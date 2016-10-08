using depross.ViewModel;
using System.Collections.Generic;

namespace depross.Interfaces
{
    public interface ICategoryWebService
    {

        #region Categories
        List<CategoryDTO> GetMainCategories(int page, int size);
 
        CategoryDTO GetMainCategory(int id);

        List<CategoryDTO> GetSubCategoriesForMain(int id);

 
        List<CategoryDTO> GetMainCategoriesBySearchString(string searchstring, int page, int size, int userid);
        #endregion

        #region Manufacturer

        #endregion

        void CreateMainCategory(CategoryDTO viewmodel);
        void CreateSubCategory(int mainid,CategoryDTO viewmodel);

    }
}
