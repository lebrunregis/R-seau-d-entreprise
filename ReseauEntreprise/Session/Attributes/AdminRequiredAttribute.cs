using Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Réseau_d_entreprise.Session.Attributes
{
    public class AdminRequiredAttribute : AuthorizeAttribute
    {
        public string RedirectActionName { get; set; }
        public string RedirectControllerName { get; set; }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool accessAllowed = false;

            if (Auth.IsAdmin(SessionUser.GetUser().Id))
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