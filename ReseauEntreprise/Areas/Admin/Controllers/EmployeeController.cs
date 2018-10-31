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
        public ActionResult Delete(int id, EmployeeList HiddenForm)
        {
            try
            {
                if (HiddenForm.Id == id)
                {
                    D.Employee e = new D.Employee()
                    {
                        Employee_Id = HiddenForm.Id,
                        LastName = HiddenForm.LastName,
                        FirstName = HiddenForm.FirstName,
                        Email = HiddenForm.Email,
                        Address = HiddenForm.Address,
                        Phone = HiddenForm.Phone,
                        RegNat = HiddenForm.RegNat
                    };
                    if (EmployeeService.Delete(e))
                    {
                        return RedirectToAction("Index");
                    }
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
