using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNet.Mvc.Filters;
using bzale.Web.Model;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;

namespace bzale.Filter
{

    public class VerifiedCompanyAttribute : AuthorizeFilter
    {
        public VerifiedCompanyAttribute(AuthorizationPolicy policy): base(policy)
        {
        }
        public override Task OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext context)
        {
            if (CurrentUser.CanSell)
            {
                return Task.FromResult(0);
            }

            return base.OnAuthorizationAsync(context);
        }
    }
}