using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Réseau_d_entreprise.Controllers
{
    public class HomeController : Controller
    {
        [AuthRequired]
        public ActionResult Index()
        {
            return View();
        }
    }
}