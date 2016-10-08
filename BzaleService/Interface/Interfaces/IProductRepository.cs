using depross.Model;
using System.Collections.Generic;

namespace depross.Interfaces

{

    public interface IProductTypeRepository
    {
        ProductType AddProductType(ProductType newproduct);

        void UpdateProductType(ProductType updatedProduct);

        ProductType GetProductTypeByID(int productid);

        List<ProductType> GetAllProductsTypesByString(string searchstring, int page, int size);

        List<ProductType> GetAllProductTypesForCategory(int categoryid,int page, int size);

        List<ProductType> GetProductsForManufacturer(Manufacturer manufacturer, int page, int size);

        /// <summary>
        /// This is for creating manufactures.
        /// A manufacturer can make products for multiple types of categories.
        /// </summary>
        /// <param name="categoryid"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<ProductType> GetAllProductTypesForCategories(List<int> categoryids,int page, int size);

    }
}
