using bzale.Model;
using System.Collections.Generic;

namespace bzale.WebService
{
    public interface ISaleListingRepository
    {
       SaleListing AddSaleListing(SaleListing newSaleListing);

       SaleListing UpdateSaleListing(SaleListing updatedSaleListing);

       SaleListing GetSaleListing(int itemid);

       void DeleteSaleListing(SaleListing SaleListing);
       void DeleteSaleListing(int id);
       List<SaleListing> GetSaleListingsForCompany(string vatnumber, int page, int size);
       List<SaleListing> GetSaleListingsForCompany(int id, int page, int size);
       List<SaleListing> GetSaleListingsForCategory(int id, int page, int size);
       List<SaleListing> GetSaleListingsBySearchString(string search, int page, int size);
       List<SaleListing> GetDeletedSaleListingsForCompany(string vatnumber, int page, int size);

       void AddNewImageForSaleListing(int SaleListingid, Image newimage);
       void RemoveImageForSaleListing(int SaleListingid, Image newimage);

       void UpdateSaleListingSubscription(SaleListing salelisting, Subscription sub);
    }          
}
