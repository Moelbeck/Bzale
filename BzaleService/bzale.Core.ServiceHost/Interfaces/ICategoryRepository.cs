using bzale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
{
    public interface ICategoryRepository
    {

        List<Category> GetCategories(int page, int size);
        List<Category> GetCategoriesWithIDs(List<int> ids);

        Category GetCategory(int categoryid);
        void AddNewCategory(Category newCategory);

        void UpdateCategory(Category category);

        List<Category> GetCategoriesBySearchString(string searchstring, int page, int size);
    }
}
