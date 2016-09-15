using System.Collections.Generic;
using bzale.Model;
using bzale.Repository.DatabaseContext;
using bzale.Repository.Abstract;
using System.Linq;
using bzale.WebService;

namespace bzale.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {


        public CategoryRepository(BzaleDatabaseContext context) : base(context)
        {
        }
        public List<Category> GetCategories(int page, int size)
        {
            return Get(e => e.Deleted == null, page, size).ToList();
        }
        public List<Category> GetCategoriesWithIDs(List<int> ids)
        {
            return Get(e => ids.Contains(e.ID) && e.Deleted == null, 1, int.MaxValue).ToList();
        }

        public Category GetCategory(int categoryid)
        {
            return (Category)GetSingle(e => e.ID == categoryid && e.Deleted == null);
        }
        public void AddNewCategory(Category newCategory)
        {
            Add(newCategory);
            Save();
        }

        public void UpdateCategory(Category category)
        {
            Edit(category);
            Save();
        }

        public List<Category> GetCategoriesBySearchString(string searchstring, int page, int size)
        {
            return Get(e => e.Name.ToLower().Contains(searchstring.ToLower()) || e.Description.ToLower().Contains(searchstring.ToLower()), page, size).ToList();
        }
    }
}
