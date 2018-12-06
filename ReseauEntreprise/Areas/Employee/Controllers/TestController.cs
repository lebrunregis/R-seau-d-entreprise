using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using SignalRChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class TestController : Controller
    {
        // GET: Employee/Test

        public ActionResult Index()
        {
            int MyId = SessionUser.GetUser().Id;
            //ChatHub.SetUserId(MyId);
            return View();
        }
    }
}