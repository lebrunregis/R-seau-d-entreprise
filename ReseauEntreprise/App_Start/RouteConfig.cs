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
                constraints: new string[] { "ReseauEntreprise.Controllers" }
            );
            routes.MapRoute(
                "Admin", // Route name
                "Admin/{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[] { "ReseauEntreprise.Admin.Controllers" }
                );
            routes.MapRoute(
    "Employee", // Route name
    "Employee/{controller}/{action}/{id}", // URL with parameters
    new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
    new string[] { "ReseauEntreprise.Employee.Controllers" }
    );
        }
    }
}
