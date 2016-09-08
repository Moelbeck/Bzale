using AutoMapper;
using bzale.Common;
using bzale.Core.ServiceHost.Repository;
using bzale.Model;
using bzale.Repository;
using bzale.Repository.DatabaseContext;
using bzale.Service;
using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bzale.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CategoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CategoryService.svc or CategoryService.svc.cs at the Solution Explorer and start debugging.
    public class CategoryWebService : ICategoryWebService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly SubCategoryRepository _subcategoryRepository;
        private ProductRepository _productRepository;
        private ManufacturerRepository _manufacturerRepository;
        public CategoryWebService(BzaleDatabaseContext context)
        {
            _categoryRepository = new CategoryRepository(context);
            _productRepository = new ProductRepository(context);
            _manufacturerRepository = new ManufacturerRepository(context);
            _subcategoryRepository = new SubCategoryRepository(context);
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


        public ProductDTO GetProductByID(int id)
        {
            try
            {
                ProductType product = _productRepository.GetProductByID(id);
                return Mapper.Map<ProductType, ProductDTO>(product);
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

        public void CreateProduct(ProductDTO viewmodel)
        {
            try
            {
                var product = Mapper.Map<ProductDTO, ProductType>(viewmodel);
                _productRepository.AddProduct(product);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void CreateManufacturer(ManufacturerDTO viewmodel)
        {
            try
            {
                var manufacturer = Mapper.Map<ManufacturerDTO, Manufacturer>(viewmodel);
                var categories = _categoryRepository.GetCategoriesWithIDs(viewmodel.CategoryIDs);

                manufacturer.Categories = categories;
                _manufacturerRepository.AddNewManufacturer(manufacturer);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ManufacturerDTO> GetManufacturersInCategory(int categoryid)
        {
            var manufacturers = _manufacturerRepository.GetManufacturersForCategory(categoryid, 1, int.MaxValue);
            return manufacturers.Select(Mapper.Map<Manufacturer, ManufacturerDTO>).ToList();
        }

        public ManufacturerDTO GetManuFacturer(int id)
        {
            var manufacturer = _manufacturerRepository.GetManufacturer(id);
            return Mapper.Map<Manufacturer, ManufacturerDTO>(manufacturer);
        }

        public List<ProductDTO> GetProductsByManufacturer(int id)
        {
            var products = _productRepository.GetAllProductsForManufacturer(id, 1, int.MaxValue);
            return products.Select(Mapper.Map<ProductType, ProductDTO>).ToList();

        }
    }

}
