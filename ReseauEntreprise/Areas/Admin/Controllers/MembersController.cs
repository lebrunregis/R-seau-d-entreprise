using D = Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Models.ViewModels;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Admin.Controllers
{
    [AdminRequired]
    [RouteArea("Admin")]
    public class MembersController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationForm form)
        {
            if (ModelState.IsValid)
            {
                D.Employee e = new D.Employee
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    Passwd = form.Password,
                    RegNat = form.RegNat,
                    Address = form.Address,
                    Phone = form.Phone
                };
                try
                {
                    Auth.Register(e);
                    return RedirectToAction("Index", "Home");
                }
                catch (System.Data.SqlClient.SqlException exeption)
                {
                    if (exeption.Number == 2627)
                    {
                        if (exeption.Message.Contains("UC_Email"))
                        {
                            ModelState.AddModelError("Email", "Cet email est déjà utilisé");
                        }
                        if (exeption.Message.Contains("UC_RegNat"))
                        {
                            ModelState.AddModelError("RegNat", "Ce numero de régistre national est déjà utilisé. Probablement, cet employé existe déjà dans la base de données.");
                        }
                    }
                    return View(form);
                }
            }
            return View(form);
        }
    }
}