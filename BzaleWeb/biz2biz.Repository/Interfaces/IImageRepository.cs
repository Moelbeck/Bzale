using System;
using System.Collections.Generic;
using biz2biz.Model;

namespace biz2biz.Repository.Interfaces
{
    public interface IImageRepository<T> : IDisposable
    {

        List<T> GetImagesForItem(Annonce annonce);

        T GetImage(int id);
        T AddNewImage(T newimage);
        void DeleteImage(T image);

    }
}
