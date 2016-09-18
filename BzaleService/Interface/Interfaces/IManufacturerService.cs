using depross.ViewModel;
using System.Collections.Generic;

namespace depross.Interfaces
{
    public interface IManufacturerService
    {
        List<ManufacturerDTO> GetManufacturersInCategory(int categoryid);
        ManufacturerDTO GetManuFacturer(int id);
        List<ProductDTO> GetProductsByManufacturer(int id);

        void CreateProduct(ProductDTO viewmodel);
        void CreateManufacturer(ManufacturerDTO viewmodel);
    }
}
