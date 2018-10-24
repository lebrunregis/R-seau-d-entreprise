using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Réseau_d_entreprise.Session.Attributes
{
    public class EmployeeRequiredAttribute : AuthorizeAttribute
    {
        public string RedirectActionName { get; set; }
        public string RedirectControllerName { get; set; }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var accessAllowed = false;

            if (SessionUser.GetSessionUser() != null)
            {
                accessAllowed = true;
            }
            return accessAllowed;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Returns HTTP 401 - see comment in HttpUnauthorizedResult.cs.
            filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                       { "action", "Index" },
                                       { "controller", "Home" }
                                       });
        }
    }
}