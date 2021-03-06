﻿using System.Collections.Generic;
using System.Linq;
using depross.Repository.DatabaseContext;
using depross.Repository.Abstract;
using depross.Model;
using depross.Interfaces;

namespace depross.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
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
            return Get(e => e.Deleted == null).OrderBy(e => e.ID)
                //.Skip((page - 1) * size).Take(size)
                .ToList();

        }

        public List<string> GetAllManufacturersNames(int page, int size)
        {
            return Get(e => e.Deleted == null).OrderBy(e => e.ID)
                //.Skip((page - 1) * size).Take(size)
                .Select(s => s.Name).ToList();
        }

        public List<Manufacturer> GetManufacturersForCategory(int categoryid, int page, int size)
        {
            return Get(e => e.ProductTypes.All(a=>a.Category.ID == categoryid) && e.Deleted == null)
                //.OrderBy(e => e.ID).Skip((page - 1) * size).Take(size)
                .ToList();
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
