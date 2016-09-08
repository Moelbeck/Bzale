using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2.Models;

namespace Web2.Repository.Interfaces
{
    public interface IAdvertiserRepository<T> : IDisposable
    {
        T GetAdvertiser(int id);
        T GetAdvertiser(string name);
        List<T> GetAllAdvertisers();
        List<T> GetActiveAdvertisers();
        T AddNewAdvertiser(T newAdvertiser);
        List<Advertisement> GetAdvertismentForAdvertiser(T advertiser);

        Advertisement GetAdvertisement(int id);

        void AddAdvertisement(T owner, Advertisement newadvertisement);
        void UpdateAdvertisement(Advertisement updatedAdvertisement);
        
        T UpdateAdvertiser(T updatedAdvertiser);

        bool IsAdvertiserInDatabase(T advertiser);
    }
}
