using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ReseauEntreprise
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "ReseauEntreprise.Controllers" }
            );
            routes.MapRoute(
                name: "Admin", // Route name
                url: "Admin/{controller}/{action}/{id}", // URL with parameters
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                namespaces: new string[] { "ReseauEntreprise.Admin.Controllers" }
                );
            routes.MapRoute(
                name: "Employee", // Route name
                url: "Employee/{controller}/{action}/{id}", // URL with parameters
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                namespaces: new string[] { "ReseauEntreprise.Employee.Controllers" }
            );
        }
    }
}
