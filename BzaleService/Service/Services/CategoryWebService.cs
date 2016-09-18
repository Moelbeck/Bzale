using AutoMapper;
using depross.Interfaces;
using depross.Model;
using depross.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace depross.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CategoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CategoryService.svc or CategoryService.svc.cs at the Solution Explorer and start debugging.
    public class CategoryWebService : ICategoryWebService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subcategoryRepository;

        public CategoryWebService(ICategoryRepository cateRepo,ISubCategoryRepository subRepo)
        {
            _categoryRepository = cateRepo;
            _subcategoryRepository = subRepo;
        }

        public List<CategoryDTO> GetMainCategories(int page, int size)
        {
            try
            {
                var allcategories = _categoryRepository.GetCategories(page, size);
                return allcategories.Select(Mapper.Map<Category, CategoryDTO>).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CategoryDTO> GetSubCategoriesForMain(int id)
        {
            try
            {
                var subcategories = _subcategoryRepository.GetSubCategoriesByMainID(id, 1, int.MaxValue);
                return subcategories.Select(Mapper.Map<SubCategory, CategoryDTO>).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public CategoryDTO GetCategory(int id)
        {
            try
            {

                var area = _categoryRepository.GetCategory(id);
                return Mapper.Map<Category, CategoryDTO>(area);

            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public List<CategoryDTO> GetCategoriesBySearchString(string searchstring, int page,int size, int userid)
        {
            try
            {
                List<Category> categories = !string.IsNullOrWhiteSpace(searchstring) ? 
                    _categoryRepository.GetCategoriesBySearchString(searchstring, page, size) 
                    : new List<Category>();
                List<CategoryDTO> allsearchedproducts = new List<CategoryDTO>();
                allsearchedproducts.AddRange(categories.Select(Mapper.Map<Category, CategoryDTO>));
                //_log.LogSearch(userid, searchstring);
                return allsearchedproducts;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void CreateMainCategory(CategoryDTO viewmodel)
        {
            try
            {
                Category newcategory = Mapper.Map<CategoryDTO, Category>(viewmodel);
                _categoryRepository.AddNewCategory(newcategory);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void CreateSubCategory(int mainid, CategoryDTO viewmodel)
        {
            try
            {
                SubCategory newcategory = Mapper.Map<CategoryDTO, SubCategory>(viewmodel);
                var main = _categoryRepository.GetCategory(mainid);
                main.SubCategories.Add(newcategory);
                _categoryRepository.UpdateCategory(main);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }

}
