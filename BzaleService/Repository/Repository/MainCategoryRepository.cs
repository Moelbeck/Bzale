using System.Collections.Generic;
using depross.Repository.DatabaseContext;
using depross.Repository.Abstract;
using System.Linq;
using depross.Model;
using depross.Interfaces;

namespace depross.Repository
{
    public class MainCategoryRepository : GenericRepository<MainCategory>, IMainCategoryRepository
    {

        public MainCategoryRepository(BzaleDatabaseContext context) : base(context)
        {
        }
        public List<MainCategory> GetMainCategories(int page, int size)
        {
            return Get(e => e.Deleted == null)
                //.OrderBy(e => e.ID).Skip((page - 1) * size).Take(size)
                .ToList();
        }
        public List<MainCategory> GetCategoriesById(List<int> ids)
        {
            return Get(e => ids.Contains(e.ID) && e.Deleted == null).ToList();
        }

        public MainCategory GetMainCategory(int categoryid)
        {
            return GetSingle(e => e.ID == categoryid && e.Deleted == null);
        }
        public void AddMainCategory(MainCategory newCategory)
        {
            Add(newCategory);
            Save();
        }

        public void UpdateMainCategory(MainCategory category)
        {
            Edit(category);
            Save();
        }

        public List<MainCategory> GetCategoriesByString(string searchstring, int page, int size)
        {
            return Get(e => e.Name.ToLower().Contains(searchstring.ToLower()) || e.Description.ToLower().Contains(searchstring.ToLower()))
                //.OrderBy(e => e.ID).Skip((page - 1) * size).Take(size)
                .ToList();
        }
    }
}
