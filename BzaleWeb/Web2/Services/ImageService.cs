using System;
using System.IO;
using AutoMapper;
using Web2.Enums;
using Web2.Models;
using Web2.Repository;
using Web2.Repository.Interfaces;
using Web2.ViewModel;
using Web2.Repository.Context;
using Microsoft.AspNet.Http;
using Microsoft.Net.Http.Headers;

namespace Web2.Service
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
            BzaleContext con = new BzaleContext();
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

        public ImageViewModel SaveImage(IFormFile file, eImageType imagetype = eImageType.Annonce)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var fileContent = reader.ReadToEnd();
                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var filename = parsedContentDisposition.FileName;
                //TODO Rethink how to save files
            }
            
            Image img = new Image
            {
                Created = DateTime.Now,
                Deleted = null,
                //ImageURL = imageurl,
                Type = imagetype
            };
            img = _imageRepository.AddNewImage(img);
            var image = Mapper.Map<Image, ImageViewModel>(img);
           // file.SaveAs(imageurl);
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
