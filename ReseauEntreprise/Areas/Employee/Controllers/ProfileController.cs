using D = Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Global.Service;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Areas.Employee.Models;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [EmployeeRequired]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            if (SessionUser.GetUser() != null && AuthService.IsAdmin(SessionUser.GetUser().Id))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "Employee" });
            }
        }

        // GET: Employee/Profile/Edit/
        public ActionResult Edit()
        {
            D.Employee e = EmployeeService.Get(SessionUser.GetUser().Id);
            EditProfileForm form = new EditProfileForm()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Address = e.Address,
                Phone = e.Phone
            };
            return View(form);
        }

        // POST: Employee/Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(EditProfileForm form)
        {
            if (ModelState.IsValid)
            {
                D.Employee e = new D.Employee()
                {
                    Employee_Id = SessionUser.GetUser().Id,
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Address = form.Address,
                    Phone = form.Phone
                };
                try
                {
                    if (EmployeeService.Update(e))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception exception)
                {
                    throw (exception);
                }
            }
            return View(form);
        }

        public ActionResult EditEmail()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult EditEmail(EditEmailForm form)
        {
            if (ModelState.IsValid)
            {
                D.Employee e = new D.Employee()
                {
                    Employee_Id = SessionUser.GetUser().Id,
                    Email = form.Email,
                    Passwd = form.Passwd
                };
                try
                {
                    if (EmployeeService.UpdateEmail(e))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("Passwd", "Mot de passe incorrect");
                }
                catch (System.Data.SqlClient.SqlException exeption)
                {
                    if (exeption.Number == 2627)
                    {
                        if (exeption.Message.Contains("UC_Email"))
                        {
                            ModelState.AddModelError("Email", "Cet email est déjà utilisé");
                        }
                    }
                }
            }
            return View(form);
        }

        public ActionResult EditPass()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult EditPass(EditPassForm form)
        {
            if (ModelState.IsValid)
            {
                string OldPass = form.OldPass;
                D.Employee e = new D.Employee()
                {
                    Employee_Id = SessionUser.GetUser().Id,
                    Passwd = form.NewPass
                };
                try
                {
                    if (EmployeeService.UpdatePassword(e, OldPass))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("OldPass", "Mot de passe incorrect");
                }
                catch (Exception exception)
                {
                    throw (exception);
                }
            }
            return View();
        }
    }
}
