using bzale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
{
    public interface IAdvertiserRepository
    {
      Advertiser GetAdvertiser(int id);

      Advertiser GetAdvertiser(string name);

      List<Advertiser> Getadvertisers(int page, int size);

      Advertiser AddNewAdvertiser(Advertiser newAdvertiser);
      Advertiser UpdateAdvertiser(Advertiser updatedAdvertiser);

      bool IsAdvertiserInDatabase(Advertiser advertiser);

    }

    public interface IAdvertisementRepository 
    {
       List<Advertisement> GetAdvertismentsForAdvertiser(Advertiser advertiser, int page, int size);

       void AddAdvertisement(Advertisement newadvertisement);

       void UpdateAdvertisement(Advertisement updatedAdvertisement);

       void AddOrUpdateImage(int adid, Image img);
    }
}
