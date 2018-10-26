using Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Models.ViewModels;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Models.ViewModels.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Réseau_d_entreprise.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Auth
        [AnonymousRequired]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
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
            if (ModelState.IsValid)
            {
                int? id = Auth.Confirm(form.Email, form.Passwd);

                if (id != null)
                {
                    SessionUser.SetUser(new User { Id = (int)id });
                    if (Auth.IsAdmin((int)id))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Employee" });
                    }

                }
                ModelState.AddModelError("Email", "Email pas enregistré ou mot de passe incorrect");
                return View(form);
            }
            return View(form);
        }

        [EmployeeRequired]
        public ActionResult Logout()
        {
            SessionUser.Reset();
            return RedirectToAction("Index", "Home");
        }
    }
}