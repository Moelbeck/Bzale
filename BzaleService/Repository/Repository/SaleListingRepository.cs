using System;
using System.Collections.Generic;
using System.Linq;
using depross.Model;
using depross.Repository.DatabaseContext;
using depross.Repository.Abstract;
using depross.Interfaces;

namespace depross.Repository
{
    public class SaleListingRepository : GenericRepository<SaleListing>, ISaleListingRepository
    {
        public SaleListingRepository(BzaleDatabaseContext context) : base(context)
        {

        }
        public SaleListing AddSaleListing(SaleListing newSaleListing)
        {
            if (newSaleListing.Owner != null && newSaleListing.CreatedBy != null && newSaleListing.CreatedBy.Company == newSaleListing.Owner)
            {
                Add(newSaleListing);
                Save();
            }
            else
            {
                newSaleListing = null;
            }
            return newSaleListing;
        }

        public SaleListing UpdateSaleListing(SaleListing updatedSaleListing)
        {
            Edit(updatedSaleListing);
            Save();
            return GetSingle(e => e.ID == updatedSaleListing.ID);
        }

        public SaleListing GetSaleListing(int itemid)
        {
            return GetSingle(e => e.ID == itemid && e.Deleted == null && e.ExpirationDate > DateTime.Now);
        }

        public void DeleteSaleListing(SaleListing SaleListing)
        {
            Delete(SaleListing);
            Save();
        }
        public void DeleteSaleListing(int id)
        {
            Delete(id);
            Save();
        }
        public List<SaleListing> GetSaleListingsForCompany(string vatnumber, int page, int size)
        {
            return Get(e => e.Owner.VAT == vatnumber && e.Deleted == null)
                //.Skip((page - 1) * size).Take(size)
                .ToList();
        }
        public List<SaleListing> GetSaleListingsForCompany(int id, int page, int size)
        {
            return Get(e => e.Owner.ID == id && e.Deleted == null)
                //.Skip((page - 1) * size).Take(size)
                .ToList();
        }
        public List<SaleListing> GetSaleListingsForCategory(int id, int page, int size)
        {
            return Get(e => e.ProductType.Category.ID == id)
                //.Skip((page - 1) * size).Take(size)
                .ToList();
        }
        public List<SaleListing> GetSaleListingsBySearchString(string search, int page, int size)
        {
            return Get(e => e.Title.Contains(search) || e.Description.Contains(search) || e.ProductType.Category.Name.Contains(search) 
            || e.ProductType.Name.Contains(search))
            //.Skip((page - 1) * size).Take(size)
            .ToList();
        }
        public List<SaleListing> GetDeletedSaleListingsForCompany(string vatnumber,int page, int size)
        {
            return Get(e => e.Owner.VAT == vatnumber && e.Deleted != null)
               // .Skip((page - 1) * size).Take(size)
                .ToList();
        }

        public void AddNewImageForSaleListing(int SaleListingid,Image newimage)
        {
            var SaleListing = GetSaleListing(SaleListingid);
            
            if (!string.IsNullOrWhiteSpace(newimage.ImageURL))
            {
                SaleListing.Images.Add(newimage);
                Edit(SaleListing);
                Save();
            }
        }

        public void RemoveImageForSaleListing(int SaleListingid, Image newimage)
        {
            var SaleListing = GetSaleListing(SaleListingid);

            if (!string.IsNullOrWhiteSpace(newimage.ImageURL))
            {
                SaleListing.Images.Remove(newimage);
                Edit(SaleListing);
                Save();
            }
        }

        public void UpdateSaleListingSubscription(SaleListing salelisting, Subscription sub)
        {
            var sale = GetSaleListing(salelisting.ID); //To be sure that we have the correct sale.
            sale.Subscription = sub;
            Edit(sale);
            Save();
        }
    }
}
