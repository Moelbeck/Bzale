using System.ServiceModel.Channels;
using System.Web;

namespace biz2biz.ViewModel
{
    /// <summary>
    /// Contains information of the current user.
    /// </summary>
    public class CurrentAccount : ISession
    {
        public static int ID
        {
            get
            {
                if (HttpContext.Current.Session["CurrentAccount"] != null)
                    return (int) HttpContext.Current.Session["CurrentAccount"];
                return -1;
            }
            set
            {
                HttpContext.Current.Session["CurrentAccount"] = value;
            }
        }

        public static string FirstName
        {
            get
            {
                return HttpContext.Current.Session["CurrentAccountFirstName"] as string;

            }
            set { HttpContext.Current.Session["CurrentAccountFirstName"] = value; }
        }
        public static string LastName
        {
            get
            {
                return HttpContext.Current.Session["CurrentAccountLastName"] as string;

            }
            set { HttpContext.Current.Session["CurrentAccountLastName"] = value; }
        }
        public static int CompanyID
        {
            get
            {
                if (HttpContext.Current.Session["CurrentAccountCompanyID"] != null)
                    return (int)HttpContext.Current.Session["CurrentAccountCompanyID"];
                return -1;
            }
            set
            {
                HttpContext.Current.Session["CurrentAccountCompanyID"] = value;
            }
        }
        public static bool HaveLoggedOut
        {
            get
            {
                if (HttpContext.Current.Session["CurrentAccountHaveLoggedOut"] != null)
                    return (bool)HttpContext.Current.Session["CurrentAccountHaveLoggedOut"];
                return false;
            }
            set
            {
                HttpContext.Current.Session["CurrentAccountHaveLoggedOut"] = value;
            }
        }
        public string Id { get; private set; }

        public static void LogOff()
        {
            ID = -1;
            HaveLoggedOut = true;
            CompanyID = -1;
            FirstName = null;
            LastName = null;
        }
    }
}
