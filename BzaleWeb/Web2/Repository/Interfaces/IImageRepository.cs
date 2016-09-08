using System;
using System.Collections.Generic;
using Web2.Models;

namespace Web2.Repository.Interfaces
{
    public interface IImageRepository<T> : IDisposable
    {

        List<T> GetImagesForItem(Annonce annonce);

        T GetImage(int id);
        T AddNewImage(T newimage);
        void DeleteImage(T image);

    }
}
