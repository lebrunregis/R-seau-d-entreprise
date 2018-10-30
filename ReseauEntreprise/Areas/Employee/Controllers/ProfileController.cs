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

namespace ReseauEntreprise.Employee.Controllers
{
    [EmployeeRequired]
    public class ProfileController : Controller
    {

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
            return View();
        }

        public ActionResult EditEmail()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EditEmail(EditEmailForm form)
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
            }
            catch (Exception exception)
            {
                throw (exception);
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
            }
            catch (Exception exception)
            {
                throw (exception);
            }
            return View();
        }
    }
}
