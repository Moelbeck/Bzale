using System;
using System.IO;
using System.Web;
using AutoMapper;
using biz2biz.Enums;
using biz2biz.Model;
using biz2biz.Repository;
using biz2biz.Repository.context;
using biz2biz.Repository.Interfaces;
using biz2biz.ViewModel;

namespace biz2biz.Service
{
    /// <summary>
    /// Handlig getting and creation of images
    /// Some methods are probably not in use
    /// </summary>
    public class ImageService
    {
        private const string Imagefolder = "/Images/";

        private readonly IImageRepository<Image> _imageRepository;

        public ImageService()
        {
            Context con = new Context();
            _imageRepository = new ImageRepository(con);
        }
        /// <summary>
        /// Creates a folder, if it doesnt exists, else it returns the name.
        /// ATTENTION!!
        ///     We need to place it in the correct place.
        /// ATTENTION!!
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetFolder(eImageType type)
        {
            var t = Directory.CreateDirectory(Imagefolder + Enum.GetName(typeof(eImageType), type));
            var newfoldername = t.FullName;
            return newfoldername;
        }
        public ImageViewModel GetImage(int id)
        {
            var image = _imageRepository.GetImage(id);
            ImageViewModel viewmodel = Mapper.Map<Image, ImageViewModel>(image);
            return viewmodel;
        }

        public ImageViewModel SaveImage(HttpPostedFileBase file, eImageType imagetype = eImageType.Annonce)
        {
            var imageurl = GetFolder(imagetype) + "/" + file.FileName;
            // file is uploaded
            file.SaveAs(imageurl);
            
            Image img = new Image
            {
                Created = DateTime.Now,
                Deleted = null,
                ImageURL = imageurl,
                Type = imagetype
            };
            img = _imageRepository.AddNewImage(img);
            var image = Mapper.Map<Image, ImageViewModel>(img);
            file.SaveAs(imageurl);
            return image;
        }

        public void RemoveImage(ImageViewModel imageviewmodel, eImageType imagetype = eImageType.Annonce)
        {
            var physicalPath = GetFolder(imagetype) + "/" + imageviewmodel.ImageURL;

            if (System.IO.File.Exists(physicalPath))
            {
                var model = Mapper.Map<ImageViewModel, Image>(imageviewmodel);
                _imageRepository.DeleteImage(model);
                System.IO.File.Delete(physicalPath);
            }
        }
        public bool ValidateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".png":
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
    }
}
