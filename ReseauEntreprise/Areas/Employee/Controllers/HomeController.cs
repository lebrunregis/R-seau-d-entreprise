using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    public class HomeController : Controller
    {
        [EmployeeRequired]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}