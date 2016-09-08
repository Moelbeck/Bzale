using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Web2.Models;
using Web2.Repository.Context;
using Web2.Repository.Interfaces;

namespace Web2.Repository
{
    public class ManufacturerRepository : IManufacturerRepository<Manufacturer>
    {
        private readonly BzaleContext context;

        public ManufacturerRepository(BzaleContext context)
        {
            this.context = context;
        }

        #region dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Manufacturer
        public Manufacturer GetManufacturer(int id)
        {
            return context.Manufacturers.FirstOrDefault(e => e.ID == id && e.Deleted == null);
        }

        public Manufacturer GetManufacturer(string name)
        {
            return context.Manufacturers.FirstOrDefault(e => e.Name.ToLower() == name.ToLower() && e.Deleted == null);
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return context.Manufacturers.Where(e => e.Deleted == null).ToList();

        }

        public List<string> GetAllManufacturersNames()
        {
            return context.Manufacturers.Where(e => e.Deleted == null).Select(s => s.Name).ToList();
        }

        public List<Manufacturer> GetManufacturersForCategory(int categoryid)
        {
            return context.Manufacturers.Where(e => e.CategoryID == categoryid && e.Deleted == null).ToList();
        }

        public Manufacturer AddNewManufacturer(Manufacturer newManufacturer)
        {
            //We need to check if the person have verified it somehow
            if (!IsManufacturerInDatabase(newManufacturer))
            {
                 context.Manufacturers.Add(newManufacturer);
                context.SaveChanges();

            }
            return newManufacturer;
        }

        public Manufacturer UpdateManufacturer(Manufacturer updated)
        {
            context.Entry(updated).State = EntityState.Modified;
            context.SaveChanges();
            return context.Manufacturers.FirstOrDefault(e => e.ID == updated.ID);
        }
        public List<Product> GetProductsForManufacturer(Manufacturer manufacturer)
        {
            List<Product> list = new List<Product>();
            list=context.Products.Where(e => e.Manufacturer.ID == manufacturer.ID).ToList();
            return list;
        }

        public List<string> GetAllProductNames()
        {
            return context.Products.Where(e => e.Deleted == null).Select(s => s.Name).ToList();
        }



        public List<Product> GetAllProductsForManufacturer(Manufacturer manufacturer)
        {
            return context.Products.Where(e => e.Deleted == null).ToList();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.Where(e => e.Deleted == null).ToList();
        } 

        public List<string> GetAllProductNamesForManufacturer(Manufacturer manufacturer)
        {
            List<Product> Products = context.Products.Where(e => e.Deleted == null && e.Manufacturer.ID == manufacturer.ID).ToList();
            return Products.Select(e => e.Name).ToList();
        }

        public bool IsManufacturerInDatabase(Manufacturer m)
        {
            return context.Manufacturers.Any(e => e.Name.ToLower() == m.Name.ToLower());
        }
        #endregion

        #region Product
        public Product AddProduct(Product newproduct)
        {
            Product product = null;
            //We need to check if the person have verified it somehow
            if (!IsProductInDatabase(newproduct))
            {
                context.Products.Add(newproduct);
                context.SaveChanges();
                product =
                    context.Products.FirstOrDefault(e => e.Name == newproduct.Name);
            }
            return product;
        }
        public void AddProductForManufacturer(Product newproduct)
        {
            if (newproduct.Manufacturer != null && IsManufacturerInDatabase(newproduct.Manufacturer) &&!IsProductInDatabase(newproduct) )
            {
                context.Products.Add(newproduct);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product updatedProduct)
        {
            context.Entry(updatedProduct).State = EntityState.Modified;
            context.SaveChanges();
        }

        private bool IsProductInDatabase(Product newproduct)
        {
            return context.Products.Any(e => e.Name.ToLower() == newproduct.Name.ToLower() && e.Manufacturer.ID == newproduct.Manufacturer.ID);
        }


        public Product GetProductByID(int productid)
        {
            return context.Products.FirstOrDefault(e => e.ID == productid);
        }



        public List<AnnonceType> GetAllAnnonceTypeContainingString(string searchstring)
        {
            var Products = context.Products.Where(e => e.Name.ToLower().Contains(searchstring) 
                || e.Manufacturer.Name.ToLower().Contains(searchstring.ToLower())
            || e.ProductCategory.Name.ToLower().Contains(searchstring.ToLower())
            || e.ProductCategory.Description.ToLower().Contains(searchstring.ToLower())).ToList();
            List<AnnonceType> annonceTypes =new List<AnnonceType>();
            annonceTypes.AddRange(Products.Select(e=>new AnnonceType
            {
                ProductID = e.ID,
                ProductName = e.Name,
                Grouping = e.ProductCategory.Name,
                ManufacturerName = e.Manufacturer.Name,
                ManufacturerID = e.ID,
                ImageURL = e.ProductCategory.Image.ImageURL
            }));
            return annonceTypes.GroupBy(x => x.ProductID).Select(y => y.First()).ToList();
        }
        #endregion



    }
}
