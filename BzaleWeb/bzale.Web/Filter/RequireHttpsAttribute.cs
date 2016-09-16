using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using bzale.Web.Model;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace bzale.Filter
{
    public class EnsureUserLoggedInAttribute : Attribute,
            IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (string.IsNullOrEmpty(CurrentUser.Email))
            {
                context.Result = new ContentResult()
                {
                    Content = "Ingen adgang, bruger skal være logget ind"
                };
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }

    public class EnsureValidCompanyAttribute : Attribute,
        IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!CurrentUser.CanSell)
            {
                context.Result = new ContentResult()
                {
                    Content = "Ingen adgang, en virksomhed med gyldigt CPR skal tilføjes for dette"
                };
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}