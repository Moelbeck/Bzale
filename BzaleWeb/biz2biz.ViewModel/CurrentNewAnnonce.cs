using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace biz2biz.ViewModel
{
   public class CurrentNewAnnonce:ISession
    {
        public static int ID
        {
            get
            {
                if (HttpContext.Current.Session["CurrentNewAnnonceID"] != null)
                    return (int)HttpContext.Current.Session["CurrentNewAnnonceID"];
                return -1;
            }
            set
            {
                HttpContext.Current.Session["CurrentNewAnnonceID"] = value;
            }
        }
        public static int ProductID
        {
            get
            {
                if (HttpContext.Current.Session["CurrentNewAnnonceProductID"] != null)
                    return (int)HttpContext.Current.Session["CurrentNewAnnonceProductID"];
                return -1;
            }
            set
            {
                HttpContext.Current.Session["CurrentNewAnnonceProductID"] = value;
            }
        }
        public static string ProductName
        {
            get
            {
                    return HttpContext.Current.Session["CurrentNewAnnonceProductName"] as string;
            }
            set
            {
                HttpContext.Current.Session["CurrentNewAnnonceProductName"] = value;
            }
        }

        public static string Title
        {
            get
            {
                return HttpContext.Current.Session["CurrentNewAnnonceTitle"] as string;

            }
            set { HttpContext.Current.Session["CurrentNewAnnonceTitle"] = value; }
        }
        public static string Description
        {
            get
            {
                return HttpContext.Current.Session["CurrentNewAnnonceDescription"] as string;

            }
            set { HttpContext.Current.Session["CurrentNewAnnonceDescription"] = value; }
        }
        public static int ManufacturerID
        {
            get
            {
                if (HttpContext.Current.Session["CurrentNewAnnonceManufacturerID"] != null)
                    return (int)HttpContext.Current.Session["CurrentNewAnnonceManufacturerID"];
                return -1;
            }
            set
            {
                HttpContext.Current.Session["CurrentNewAnnonceManufacturerID"] = value;
            }
        }
        public static string ManufacturerName
        {
            get
            {
                    return HttpContext.Current.Session["CurrentNewAnnonceManufacturerName"] as string;
            }
            set
            {
                HttpContext.Current.Session["CurrentNewAnnonceManufacturerName"] = value;
            }
        }
        public static int ProductCategoryID
       {
            get
            {
                if (HttpContext.Current.Session["CurrentNewAnnonceProductCategoryID"] != null)
                    return (int)HttpContext.Current.Session["CurrentNewAnnonceProductCategoryID"];
                return -1;
            }
            set
            {
                HttpContext.Current.Session["CurrentNewAnnonceProductCategoryID"] = value;
            }
        }
        public static List<ImageViewModel> Images
        {
            get
            {
                if(HttpContext.Current.Session["CurrentNewAnnonceImages"] as List<ImageViewModel> ==null) 
                    HttpContext.Current.Session["CurrentNewAnnonceImages"] = new List<ImageViewModel>();
                    return HttpContext.Current.Session["CurrentNewAnnonceImages"] as List<ImageViewModel>;
            }
            set
            {
                if (HttpContext.Current.Session["CurrentNewAnnonceImages"] as List<ImageViewModel> == null)
                    HttpContext.Current.Session["CurrentNewAnnonceImages"] = new List<ImageViewModel>();
                HttpContext.Current.Session["CurrentNewAnnonceImages"] = value;
            }
        }

       public static List<HttpPostedFileBase> ImageFiles
       {
            get
            {
                if (HttpContext.Current.Session["CurrentNewAnnonceImageFiles"] as List<HttpPostedFileBase> == null)
                    HttpContext.Current.Session["CurrentNewAnnonceImageFiles"] = new List<HttpPostedFileBase>();
                return HttpContext.Current.Session["CurrentNewAnnonceImageFiles"] as List<HttpPostedFileBase>;
            }
            set
            {
                if (HttpContext.Current.Session["CurrentNewAnnonceImageFiles"] as List<HttpPostedFileBase> == null)
                    HttpContext.Current.Session["CurrentNewAnnonceImageFiles"] = new List<HttpPostedFileBase>();
                HttpContext.Current.Session["CurrentNewAnnonceImageFiles"] = value;
            }
        }
        public string Id { get; private set; }

       public static void SetToNull()
       {
           ID = -1;
           ManufacturerID = -1;
           ProductID = -1;
           Description = null;
           ProductName = null;
           Title = null;
            ImageFiles= new List<HttpPostedFileBase>();
            Images= new List<ImageViewModel>();
       }
    }
}
