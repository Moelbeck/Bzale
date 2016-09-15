using bzale.Model;
using bzale.Repository.Abstract;
using bzale.Repository.DatabaseContext;
using bzale.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {

        public SubCategoryRepository(BzaleDatabaseContext context) : base(context)
        {

        }
        public List<SubCategory> GetSubCategoriesByMainID(int maincategory,int page, int size)
        {
            return Get(e => e.MainCategory.ID == maincategory && e.Deleted == null, page, size).ToList();
        }

        public SubCategory GetSubCategory(int categoryid)
        {
            return GetSingle(e => e.ID == categoryid && e.Deleted == null);
        }
        public void AddNewSubCategory(SubCategory newCategory)
        {
            Add(newCategory);
            Save();
        }

        public void UpdateSubCategory(SubCategory category)
        {
            Edit(category);
            Save();
        }
    }

}
