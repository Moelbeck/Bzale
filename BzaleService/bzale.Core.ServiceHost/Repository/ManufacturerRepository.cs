using System;
using System.Collections.Generic;
using System.Linq;
using bzale.Model;
using bzale.Repository.DatabaseContext;
using bzale.Repository.Abstract;

namespace bzale.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>
    {
        public ManufacturerRepository(BzaleDatabaseContext context) : base(context)
        {

        }

        #region Manufacturer
        public Manufacturer GetManufacturer(int id)
        {
            return GetSingle(e => e.ID == id && e.Deleted == null);
        }

        public Manufacturer GetManufacturer(string name)
        {
            return GetSingle(e => e.Name.ToLower() == name.ToLower() && e.Deleted == null);
        }

        public List<Manufacturer> GetAllManufacturers(int page, int size)
        {
            return Get(e => e.Deleted == null,page,size).ToList();

        }

        public List<string> GetAllManufacturersNames(int page, int size)
        {
            return Get(e => e.Deleted == null,page,size).Select(s => s.Name).ToList();
        }

        public List<Manufacturer> GetManufacturersForCategory(int categoryid, int page, int size)
        {
            return Get(e => e.Categories.All(c=>c.ID == categoryid) && e.Deleted == null, page,size).ToList();
        }

        public Manufacturer AddNewManufacturer(Manufacturer newManufacturer)
        {
            //We need to check if the person have verified it somehow
            if (!IsManufacturerInDatabase(newManufacturer))
            {
                Add(newManufacturer);
                Save();

            }
            return newManufacturer;
        }

        public Manufacturer UpdateManufacturer(Manufacturer updated)
        {
            Edit(updated);
            Save();
            return GetSingle(e => e.ID == updated.ID);
        }

        public bool IsManufacturerInDatabase(Manufacturer m)
        {
            return GetSingle(e => e.Name.ToLower() == m.Name.ToLower())!=null;
        }
        #endregion




    }
}
