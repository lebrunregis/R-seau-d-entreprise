using D=Model.Global.Data;
using Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Employee;
using Réseau_d_entreprise.Session.Attributes;

namespace ReseauEntreprise.Admin.Controllers
{
    [AdminRequired]
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeList> AllEmployees = EmployeeService.GetAllActive()
                .Select(e => new EmployeeList()
                {
                    Id = e.Employee_Id,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Email = e.Email,
                    Address = e.Address,
                    Phone = e.Phone,
                    RegNat = e.RegNat
                });
            return View(AllEmployees);
        }

        public ActionResult Delete(int id)
        {
            D.Employee emp = EmployeeService.Get(id);
            EmployeeList e = new EmployeeList()
            {
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                Email = emp.Email,
                Address = emp.Address,
                Phone = emp.Phone,
                RegNat = emp.RegNat
            };
            return View(e);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (EmployeeService.Delete(id))
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
