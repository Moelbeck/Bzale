using System.Web;
using System.Web.Mvc;
using biz2biz.ViewModel;

namespace biz2biz.Web.Authorize
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = CurrentAccount.ID>0;
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}