using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
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
