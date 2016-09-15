using bzale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService

{

    public interface IProductRepository
    {
        ProductType AddProduct(ProductType newproduct);

        void UpdateProduct(ProductType updatedProduct);

        ProductType GetProductByID(int productid);


        List<ProductType> GetAllProductsContainingString(string searchstring, int page, int size);


        List<string> GetAllProductNames(int page, int size);


        List<ProductType> GetAllProductsForManufacturer(int manufacturer, int page, int size);

        List<ProductType> GetAllProducts(int page, int size);

        List<string> GetAllProductNamesForManufacturer(Manufacturer manufacturer, int page, int size);

        List<ProductType> GetProductsForManufacturer(Manufacturer manufacturer, int page, int size);
        bool IsManufacturerInDatabase(Manufacturer m);

    }
}
