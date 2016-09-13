using App.Web;
using bzale.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                if (AppHttpContext.Current.Session.IsAvailable && AppHttpContext.Current.Session.GetInt32("id") != null)
                {
                    id = (int)AppHttpContext.Current.Session.GetInt32("id");

                }
                return id;
            }
            set
            {
                AppHttpContext.Current.Session.SetInt32("id", value);
            }
        }
        public static string Email
        {
            get
            {
                string mail = null;
                if (AppHttpContext.Current.Session.IsAvailable && AppHttpContext.Current.Session.GetString("email") != null)
                {
                    mail = AppHttpContext.Current.Session.GetString("email") as string;
                }
                return mail;
            }
            set
            {
                AppHttpContext.Current.Session.SetString("email", value);
            }
        }
        public static string FirstName
        {
            get
            {
                string firstname = null;
                if (AppHttpContext.Current.Session.IsAvailable && AppHttpContext.Current.Session.GetString("firstname") != null)
                {
                    firstname = AppHttpContext.Current.Session.GetString("firstname") as string;
                }
                return firstname;
            }
            set
            {
                AppHttpContext.Current.Session.SetString("firstname", value);
            }
        }
        public static string LastName
        {
            get
            {
                string lastname = null;
                if (AppHttpContext.Current.Session.IsAvailable && AppHttpContext.Current.Session.GetString("lastname") != null)
                {
                    lastname = AppHttpContext.Current.Session.GetString("lastname") as string;
                }
                return lastname;
            }
            set
            {
                AppHttpContext.Current.Session.SetString("lastname", value);
            }
        }
        public static string CompanyVAT
        {
            get
            {
                string vat = null;
                if (AppHttpContext.Current.Session.IsAvailable && AppHttpContext.Current.Session.GetString("vat") != null)
                {
                    vat = AppHttpContext.Current.Session.GetString("vat") as string;
                }
                return vat;
            }
            set
            {
                AppHttpContext.Current.Session.SetString("vat", value);
            }
        }
        public static bool CanSell
        {
            get
            {
                int canselltemp = 0;
                if (AppHttpContext.Current.Session.IsAvailable && AppHttpContext.Current.Session.GetInt32("cansell") != null)
                {
                    canselltemp = (int)AppHttpContext.Current.Session.GetInt32("cansell");
                }
                bool cansell = Convert.ToBoolean(canselltemp);
                return cansell;
            }
            set
            {
                AppHttpContext.Current.Session.SetInt32("vat", value == true ? 1 : 0);
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
