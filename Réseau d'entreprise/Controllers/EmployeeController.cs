using Model.Global.Service;
using Réseau_d_entreprise.Models.ViewModels;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Réseau_d_entreprise.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Auth
        [AnonymousRequired]
        public ActionResult Index()
        {
            return View();
        }

        [AnonymousRequired]
        public ActionResult Login()
        {
            return View();
        }

        [AnonymousRequired]
        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            int? id = Auth.Confirm(form.Login, form.Passwd);

            if (id != null)
            {
                SessionUser.SetSessionUser(new User { Id = (int)id });
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        [AnonymousRequired]
        public ActionResult Register()
        {
            return View();
        }

        [AnonymousRequired]
        [HttpPost]
        public ActionResult Register(RegistrationForm form)
        {
  /*          int count = Auth.Register(form.Login, form.Email, form.Passwd);
            if (count == 1)
            {
                return RedirectToAction("index", "Auth");
            }*/
            return View();
        }
    }
}