using System;
using System.Collections.Generic;
using System.Linq;
using bzale.Model;
using bzale.Repository.DatabaseContext;
using bzale.Repository.Abstract;

namespace bzale.Repository
{
   public class AdvertiserRepository : GenericRepository< Advertiser>
    {
        public AdvertiserRepository(BzaleDatabaseContext context) : base(context)
        {

        }
       public Advertiser GetAdvertiser(int id)
       {
           return GetSingle(e => e.ID == id && e.Deleted==null);
       }

       public Advertiser GetAdvertiser(string name)
       {
           return GetSingle(e => e.Name.ToLower() == name.ToLower() && e.Deleted == null);

       }

       public List<Advertiser> Getadvertisers(int page,int size)
       {
           return Get(e => e.Deleted == null,page,size).ToList();
       }

       public Advertiser AddNewAdvertiser(Advertiser newAdvertiser)
       {
           if (!IsAdvertiserInDatabase(newAdvertiser))
           {
                Add(newAdvertiser);
                Save();
            }
           return newAdvertiser;
       }
       public Advertiser UpdateAdvertiser(Advertiser updatedAdvertiser)
       {
            updatedAdvertiser.Updated = DateTime.Now;
            Edit(updatedAdvertiser);;
           return GetSingle(e => e.ID == updatedAdvertiser.ID);
       }

        public bool IsAdvertiserInDatabase(Advertiser advertiser)
        {
            return GetSingle(e => e.Name.Equals(advertiser.Name,StringComparison.CurrentCultureIgnoreCase) && e.Deleted ==null)!=null;
        }

    }

    public class AdvertisementRepository : GenericRepository<Advertisement>
    {
        public AdvertisementRepository(BzaleDatabaseContext context) : base(context)
        {

        }
        public List<Advertisement> GetAdvertismentsForAdvertiser(Advertiser advertiser,int page, int size)
        {
            List<Advertisement> advertisements = new List<Advertisement>();

            advertisements = Get(e => e.Advertiser.ID == advertiser.ID,page,size).ToList();
            return advertisements;
        }


        public void AddAdvertisement(Advertisement newadvertisement)
        {
            Add(newadvertisement);
            Save();
            
        }

        public void UpdateAdvertisement(Advertisement updatedAdvertisement)
        {
            Edit(updatedAdvertisement);
            Save();
        }

        public void AddOrUpdateImage(int adid, Image img)
        {
            var ad =GetSingle(e => e.ID == adid);
            ad.Image = img;
            Edit(ad);
            Save();
        }
    }
}
