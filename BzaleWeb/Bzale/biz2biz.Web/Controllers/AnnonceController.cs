using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using biz2biz.Service;
using biz2biz.ViewModel;
using biz2biz.ViewModel.AnnonceViewModels;
using biz2biz.Web.Authorize;

namespace biz2biz.Web.Controllers
{
    /// <summary>
    /// This controller will handling everything that is with Annonce's to do.
    /// </summary>
    [CustomAuthorize]
    public class AnnonceController : Controller
    {
        private AnnonceService _annonceService;
        private ImageService _imageService;
        public AnnonceController()
            : this( new AnnonceService(), new ImageService())
        {
        }

        public AnnonceController( AnnonceService annonceService, ImageService imageService)
        {
            _annonceService = annonceService;
            _imageService = imageService;
        }
        // GET: Annonce
        public ActionResult SelectAnnonceType()
        {
            if (CurrentNewAnnonce.Images.Any())
            {
                string[] imageurls = CurrentNewAnnonce.Images.Select(e => e.ImageURL).ToArray();
                RemoveImage(imageurls);
            }
            CurrentNewAnnonce.SetToNull();
            
            return View();
        }
        public string SetAnnonceType(AnnonceTypeViewModel model)
        {
            string retvalue = "False";
            if (model.ProductID > 0)
            {
                CurrentNewAnnonce.ProductID = model.ProductID;
                CurrentNewAnnonce.ManufacturerID = model.ManufacturerID;
                CurrentNewAnnonce.ProductName = model.ProductName;
                CurrentNewAnnonce.ManufacturerName = model.ManufacturerName;
                CurrentNewAnnonce.ProductCategoryID = model.ProductCategoryID;
                retvalue = "True";
            }
            return retvalue;
        }

        public ActionResult NewAnnonce(int id)
        {
            if (CurrentNewAnnonce.ProductID < 0)
            {
                var producttypemodel = _annonceService.GetProductByID(id);
                CurrentNewAnnonce.ProductID = producttypemodel.ID;
                CurrentNewAnnonce.ProductName = producttypemodel.Name;
            }
            var model = new AnnonceCreateViewModel
            {
                ManufacturerName = CurrentNewAnnonce.ManufacturerName,
                ManufacturerID = CurrentNewAnnonce.ManufacturerID,
                ProductName = CurrentNewAnnonce.ProductName,
                ProductID = CurrentNewAnnonce.ProductID,
                ProductCategoryID = CurrentNewAnnonce.ProductCategoryID
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAnnonce(AnnonceCreateViewModel newannonce)
        {
            if (ModelState.IsValid)
            {

                 _annonceService.CreateNewAnnonce(CurrentAccount.ID,newannonce);
            }
            return View();
        }

        public ActionResult AnnonceTypes_Read(string text)
        {
            var annoncer = _annonceService.GetAnnonceTypes(text);
            return Json(annoncer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTempImage(IEnumerable<HttpPostedFileBase> Images)
        {
            if (Images != null)
            {
                foreach (var file in Images)
                {
                    var extension =Path.GetExtension(file.FileName);
                    if (_imageService.ValidateExtension(extension))
                    {
                        CurrentNewAnnonce.ImageFiles.Add(file);
                    }
                }
            }
            return Content("");
        }

        private void SaveImages(IEnumerable<HttpPostedFileBase> images)
        {
            if (images != null)
            {
                foreach (var file in images)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (_imageService.ValidateExtension(extension))
                    {
                        var addedimage = _imageService.SaveImage(file);
                    }
                }
            }
        }

        public ActionResult RemoveTempImage(string[] fileNames)
        {
            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var image = CurrentNewAnnonce.Images.FirstOrDefault(e => e.ImageURL.ToLower() == fullName.ToLower());

                    if (image != null)
                    {
                        CurrentNewAnnonce.Images.Remove(image);
                    }
                }
            }
            return Content("");
        }
        public ActionResult RemoveImage(string[] fileNames)
        {
            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var image = CurrentNewAnnonce.Images.FirstOrDefault(e => e.ImageURL.ToLower() == fullName.ToLower());

                    if (image != null)
                    {
                        _imageService.RemoveImage(image);
                    }
                }
            }
            return Content("");
        }
    }
}