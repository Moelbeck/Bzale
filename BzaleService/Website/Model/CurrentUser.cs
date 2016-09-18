using App.Web;
using depross.ViewModel;
using System;
using System.Web;

namespace bzale.Web.Model
{
    public static class CurrentUser 
    {
        //private static readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        
        //private  ISession _session;

        public static int ID
        {
            get
            {
                int id = 0;
                if (HttpContext.Current.Session["id"] != null)
                {
                    id = (int)HttpContext.Current.Session["id"];

                }
                return id;
            }
            set
            {
                HttpContext.Current.Session["id"] = value;
            }
        }
        public static string Email
        {
            get
            {
                string mail = null;
                if (HttpContext.Current.Session["email"] != null)
                {
                    mail = HttpContext.Current.Session["email"] as string;
                }
                return mail;
            }
            set
            {
                HttpContext.Current.Session["email"] = value;
            }
        }
        public static string FirstName
        {
            get
            {
                string firstname = null;
                if ( HttpContext.Current.Session["firstname"] != null)
                {
                    firstname = HttpContext.Current.Session["firstname"] as string;
                }
                return firstname;
            }
            set
            {
                HttpContext.Current.Session["firstname"] = value;
            }
        }
        public static string LastName
        {
            get
            {
                string lastname = null;
                if (HttpContext.Current.Session["lastname"] != null)
                {
                    lastname = HttpContext.Current.Session["lastname"] as string;
                }
                return lastname;
            }
            set
            {
                HttpContext.Current.Session["lastname"] = value;
            }
        }
        public static string CompanyVAT
        {
            get
            {
                string vat = null;
                if (HttpContext.Current.Session["vat"] != null)
                {
                    vat = HttpContext.Current.Session["vat"] as string;
                }
                return vat;
            }
            set
            {
                HttpContext.Current.Session["vat"] = value;
            }
        }
        public static bool CanSell
        {
            get
            {
                int canselltemp = 0;
                if (HttpContext.Current.Session["cansell"] != null)
                {
                    canselltemp = (int)HttpContext.Current.Session["cansell"];
                }
                bool cansell = Convert.ToBoolean(canselltemp);
                return cansell;
            }
            set
            {
                HttpContext.Current.Session["vat"]  = value == true ? 1 : 0;
            }
        }
        public static void InstantiateCurrentUser(AccountDTO acc)
        {
            ID = acc.ID;
            FirstName = acc.FirstName;
            LastName = acc.LastName;
            Email = acc.Email;
            CanSell = acc.Company==null?false:acc.Company.IsVerified;
        }

        public static void SetCurrentUserToNull()
        {
            ID = 0;
            FirstName = null;
            LastName = null;
            Email = null;
            CanSell =false;
        }
    }
}
