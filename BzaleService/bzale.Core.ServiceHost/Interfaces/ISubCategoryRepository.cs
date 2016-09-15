using bzale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
{
    public interface ISubCategoryRepository
    {
        List<SubCategory> GetSubCategoriesByMainID(int maincategory, int page, int size);

        SubCategory GetSubCategory(int categoryid);
        void AddNewSubCategory(SubCategory newCategory);

        void UpdateSubCategory(SubCategory category);
    }
}
