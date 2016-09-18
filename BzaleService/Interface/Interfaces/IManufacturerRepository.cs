using depross.Model;
using System.Collections.Generic;

namespace depross.Interfaces
{
    public interface IManufacturerRepository
    {

        Manufacturer GetManufacturer(int id);

        Manufacturer GetManufacturer(string name);

        List<Manufacturer> GetAllManufacturers(int page, int size);

        List<string> GetAllManufacturersNames(int page, int size);
        List<Manufacturer> GetManufacturersForCategory(int categoryid, int page, int size);

        Manufacturer AddNewManufacturer(Manufacturer newManufacturer);
        

        Manufacturer UpdateManufacturer(Manufacturer updated);
        bool IsManufacturerInDatabase(Manufacturer m);


    }
}
