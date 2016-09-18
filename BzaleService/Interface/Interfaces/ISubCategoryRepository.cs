using depross.Model;
using System.Collections.Generic;

namespace depross.Interfaces
{
    public interface ISubCategoryRepository
    {
        List<SubCategory> GetSubCategoriesByMainID(int maincategory, int page, int size);

        SubCategory GetSubCategory(int categoryid);
        void AddNewSubCategory(SubCategory newCategory);

        void UpdateSubCategory(SubCategory category);
    }
}
