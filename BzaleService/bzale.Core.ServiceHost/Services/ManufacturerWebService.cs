using AutoMapper;
using bzale.Model;
using bzale.Repository;
using bzale.Repository.DatabaseContext;
using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
{
    public class ManufacturerWebService : IManufacturerService

    {
        private IProductRepository _productRepository;
        private IManufacturerRepository _manufacturerRepository;
        private ICategoryRepository _categoryRepository;
        public ManufacturerWebService(IProductRepository prodRepo,IManufacturerRepository manuRepo, ICategoryRepository catRepo)
        {
            _productRepository = prodRepo;
            _manufacturerRepository = manuRepo;
            _categoryRepository = catRepo;
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
