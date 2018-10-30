using Model.Global.Service;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (SessionUser.GetUser() != null && AuthService.IsAdmin(SessionUser.GetUser().Id))
            {
                RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else if (SessionUser.GetUser()!= null)
            {
                RedirectToAction("Index", "Home", new { area = "Employee" });
            } else
            {
                RedirectToAction("Index", "Home", new { area = "Default" });
            }
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