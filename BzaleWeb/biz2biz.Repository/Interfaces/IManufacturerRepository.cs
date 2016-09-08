using System;
using System.Collections.Generic;
using biz2biz.Model;

namespace biz2biz.Repository.Interfaces
{
    public interface IManufacturerRepository<T> : IDisposable
    {
        T GetManufacturer(int id);
        T GetManufacturer(string name);

        List<T> GetAllManufacturers();
        List<string> GetAllManufacturersNames();
        List<T> GetManufacturersForCategory(int categoryid);

        T AddNewManufacturer(T newManufacturer);

        T UpdateManufacturer(T updated);

        List<Product> GetProductsForManufacturer(T manufacturer);
        List<string> GetAllProductNames();
        List<Product> GetAllProducts();
        List<Product> GetAllProductsForManufacturer(T manufacturer);
        List<string> GetAllProductNamesForManufacturer(T manufacturer);

        void AddProductForManufacturer(Product newproduct);
        void UpdateProduct(Product updatedProduct);

        bool IsManufacturerInDatabase(T m);

        Product GetProductByID(int productId);

        List<AnnonceType> GetAllAnnonceTypeContainingString(string searchstring);
    }
}
