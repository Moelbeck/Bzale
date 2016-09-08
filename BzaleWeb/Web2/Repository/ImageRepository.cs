using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Web2.Models;
using Web2.Repository.Context;
using Web2.Repository.Interfaces;

namespace Web2.Repository
{
    public class ImageRepository : IImageRepository<Image>
    {
        private readonly BzaleContext context;

        public ImageRepository(BzaleContext context)
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

        public List<Image> GetImagesForItem(Annonce annonce)
        {
            throw new NotImplementedException();
        }

        public Image GetImage(int id)
        {
            return context.Images.FirstOrDefault(e => e.ID == id && e.Deleted==null);
        }

        public Image AddNewImage(Image newimage)
        {
            if (!string.IsNullOrWhiteSpace(newimage.ImageURL))
            {
                context.Images.Add(newimage);
                context.SaveChanges();
            }
            return newimage;

        }


        public void DeleteImage(Image image)
        {
            image.Deleted = DateTime.Now;
            context.Entry(image).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
