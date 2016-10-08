using depross.Model;
using System.Collections.Generic;

namespace depross.Interfaces
{
    public interface IMainCategoryRepository
    {

        List<MainCategory> GetMainCategories(int page, int size);
        List<MainCategory> GetCategoriesById(List<int> ids);

        MainCategory GetMainCategory(int categoryid);
        void AddMainCategory(MainCategory newCategory);

        void UpdateMainCategory(MainCategory category);

        List<MainCategory> GetCategoriesByString(string searchstring, int page, int size);
    }
}
