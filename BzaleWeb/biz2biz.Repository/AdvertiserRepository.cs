using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using biz2biz.Model;
using biz2biz.Repository.context;
using biz2biz.Repository.Interfaces;

namespace biz2biz.Repository
{
   public class AdvertiserRepository : IAdvertiserRepository<Advertiser>
   {
        private readonly Context context;

        public AdvertiserRepository(Context context)
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

       public Advertiser GetAdvertiser(int id)
       {
           return context.Advertisers.FirstOrDefault(e => e.ID == id && e.Deleted==null);
       }

       public Advertiser GetAdvertiser(string name)
       {
           return context.Advertisers.FirstOrDefault(e => e.Name.ToLower() == name.ToLower() && e.Deleted == null);

       }

       public List<Advertiser> GetAllAdvertisers()
       {
           return context.Advertisers.Where(e => e.Deleted == null).ToList();
       }
       //Needs some way to check if they are active
       public List<Advertiser> GetActiveAdvertisers()
       {
           return context.Advertisers.Where(e => e.Deleted == null).ToList();
       }

       public Advertiser AddNewAdvertiser(Advertiser newAdvertiser)
       {
           if (!IsAdvertiserInDatabase(newAdvertiser))
           {
               context.Advertisers.Add(newAdvertiser);
               context.SaveChanges();
           }
           return newAdvertiser;
       }
       public Advertiser UpdateAdvertiser(Advertiser updatedAdvertiser)
       {
           context.Entry(updatedAdvertiser).State = EntityState.Modified;
           context.SaveChanges();
           return context.Advertisers.FirstOrDefault(e => e.ID == updatedAdvertiser.ID);
       }
       public List<Advertisement> GetAdvertismentForAdvertiser(Advertiser advertiser)
       {
          List<Advertisement> advertisements = new List<Advertisement>();
           foreach (var source in context.Advertisers.Where(e=>e.ID == advertiser.ID))
           {
               advertisements.AddRange(source.Advertisements);
           }
           return advertisements;
       }

       public Advertisement GetAdvertisement(int id)
       {
           return context.Advertisements.FirstOrDefault(e => e.ID == id);
       }

       public void AddAdvertisement(Advertiser owner, Advertisement newadvertisement)
       {
           if (IsAdvertiserInDatabase(owner))
           {
               context.Advertisements.Add(newadvertisement);
               context.SaveChanges();
               owner.Advertisements.Add(newadvertisement);
               UpdateAdvertiser(owner);
           }
       }

       public void UpdateAdvertisement(Advertisement updatedAdvertisement)
       {
           context.Entry(updatedAdvertisement).State = EntityState.Modified;
           context.SaveChanges();
       }



       public bool IsAdvertiserInDatabase(Advertiser advertiser)
       {
           return context.Advertisers.Any(e => e.Name.ToLower() == advertiser.Name.ToLower());
       }
   }
}
