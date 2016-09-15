using bzale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
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
