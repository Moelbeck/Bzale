using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz2biz.Model;

namespace biz2biz.Repository.Interfaces
{
    public interface ICategoryRepository : IDisposable
    {

        List<JobCategory> GetJobCategories();
        List<ProductCategory> GetProductCategories_FromJobCategory(JobCategory maincategory);
        List<ProductCategory> GetProductCategories_FromJobCategory(int maincategory);

        JobCategory GetSpecificJobCategory(int categoryid);
        JobCategory GetSpecificJobCategory(string categoryname);

        ProductCategory GetSpecificProductCategory(int jobcategoryid);
        ProductCategory GetSpecificProductCategory(string jobcategoryname);

        void AddNewJobCategory(JobCategory newCategory);
        void AddNewProductCategory(ProductCategory newproductcategory);

        void UpdateJobCategory(JobCategory category);
        void UpdateProductCategory(ProductCategory category);
        List<ProductCategory> GetAllProductCategories();
        List<ProductCategory> GetAllProductCategoriesContainingString(string searchstring);
    }
}
