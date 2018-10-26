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
            catch
            {
                
            }
            return View();
        }
    }
}
