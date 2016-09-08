using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz2biz.Model;
using biz2biz.Repository.context;
using biz2biz.Repository.Interfaces;

namespace biz2biz.Repository
{
   public class CategoryRepository : ICategoryRepository
   {
       private Context context;

       public CategoryRepository(Context context)
       {
           this.context = context;
       }

       #region dispose
       private bool disposed = false;
       protected virtual void Dispose(bool disposing)
       {
           if (!this.disposed)
           {
               if (disposing)
               {
                   context.Dispose();
               }
           }
           this.disposed = true;
       }

       public void Dispose()
       {
           Dispose(true);
           GC.SuppressFinalize(this);
       }
       #endregion


       public List<JobCategory> GetJobCategories()
       {
           List<JobCategory> categories = context.JobCategories.ToList();
           return categories;
       }

       public List<ProductCategory> GetProductCategories_FromJobCategory(JobCategory maincategory)
       {
           return context.ProductCategories.Where(e => e.JobCategories.Contains(maincategory)).ToList();
       }

       public List<ProductCategory> GetProductCategories_FromJobCategory(int maincategory)
       {
            return context.ProductCategories.Where(e => e.JobCategories.FirstOrDefault(s=>s.ID ==maincategory)!=null).ToList();
        }

        public JobCategory GetSpecificJobCategory(int categoryid)
       {
            return context.JobCategories.FirstOrDefault(e=>e.ID == categoryid);
        }

        public JobCategory GetSpecificJobCategory(string categoryname)
       {
            return context.JobCategories.FirstOrDefault(e => e.Name.ToLower() == categoryname.ToLower());
        }

        public ProductCategory GetSpecificProductCategory(int jobcategoryid)
        {
            return context.ProductCategories.FirstOrDefault(e => e.ID == jobcategoryid);
        }

       public ProductCategory GetSpecificProductCategory(string jobcategoryname)
       {
            return context.ProductCategories.FirstOrDefault(e => e.Name.ToLower() == jobcategoryname.ToLower());
        }

        public void AddNewJobCategory(JobCategory newCategory)
       {

                context.JobCategories.Add(newCategory);
                context.SaveChanges();
            
        }

       public void AddNewProductCategory(ProductCategory newproductcategory)
       {
            context.ProductCategories.Add(newproductcategory);
            context.SaveChanges();
        }

       public void UpdateJobCategory(JobCategory category)
       {
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
            //return context.JobCategories.FirstOrDefault(e => e.ID == category.ID);
        }

       public void UpdateProductCategory(ProductCategory category)
       {
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }

       public List<ProductCategory> GetAllProductCategories()
       {
           return context.ProductCategories.ToList();
       }
        public List<ProductCategory> GetAllProductCategoriesContainingString(string searchstring)
        {
            return context.ProductCategories.Where(e=>e.Name.ToLower().Contains(searchstring.ToLower()) || e.Description.ToLower().Contains(searchstring.ToLower())).ToList();
        }
    }
}
