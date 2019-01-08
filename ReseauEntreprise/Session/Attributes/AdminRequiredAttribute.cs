using Model.Client.Service;
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

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool accessAllowed = false;

            if (SessionUser.GetUser() != null && AuthService.IsAdmin(SessionUser.GetUser().Id))
            {
                accessAllowed = true;
            }
            return accessAllowed;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                       { "action", "AccessDenied" },
                                       { "controller", "Home" },
                                       { "Area", "Employee" }
                                       });
        }
    }
}