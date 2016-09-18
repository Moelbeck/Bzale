using System;
using bzale.Web.Model;

namespace bzale.Filter
{
    //public class EnsureUserLoggedInAttribute : Attribute,
    //        IResourceFilter
    //{
    //    public void OnResourceExecuting(ResourceExecutingContext context)
    //    {
    //        if (string.IsNullOrEmpty(CurrentUser.Email))
    //        {
    //            context.Result = new ContentResult()
    //            {
    //                Content = "Ingen adgang, bruger skal være logget ind"
    //            };
    //        }
    //    }

    //    public void OnResourceExecuted(ResourceExecutedContext context)
    //    {
    //    }
    //}

    //public class EnsureValidCompanyAttribute : Attribute,
    //    IResourceFilter
    //{
    //    public void OnResourceExecuting(ResourceExecutingContext context)
    //    {
    //        if (!CurrentUser.CanSell)
    //        {
    //            context.Result = new ContentResult()
    //            {
    //                Content = "Ingen adgang, en virksomhed med gyldigt CPR skal tilføjes for dette"
    //            };
    //        }
    //    }

    //    public void OnResourceExecuted(ResourceExecutedContext context)
    //    {
    //    }
    //}
}