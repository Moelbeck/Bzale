using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using biz2biz.Model;
using biz2biz.Repository;
using biz2biz.Repository.context;
using biz2biz.Repository.Interfaces;
using biz2biz.ViewModel;

namespace biz2biz.Service
{
    /// <summary>
    /// Contains service calls for Area and JobCategory
    /// </summary>
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        //private static AccountService _singleton;
        public CategoryService()
        {
            var context = new Context();
            _categoryRepository = new CategoryRepository(context);
        }

        public List<CategoryViewModel> GetJobCategories()
        {
            var allareas = _categoryRepository.GetJobCategories();
            return allareas.Select(Mapper.Map<JobCategory, CategoryViewModel>).ToList();
        }

        public CategoryViewModel GetSelectedJobCategory(int id)
        {
            var area = _categoryRepository.GetSpecificJobCategory(id);
            return Mapper.Map<JobCategory, CategoryViewModel>(area);
        }
        public List<CategoryViewModel> GetProductCategorisByJob(int id)
        {
            var categories = _categoryRepository.GetProductCategories_FromJobCategory(id);
            return categories.Select(Mapper.Map<ProductCategory, CategoryViewModel>).ToList();
        } 
    }
}
