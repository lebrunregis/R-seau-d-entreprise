using C = Model.Client.Data;
using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Employee;
using Réseau_d_entreprise.Session.Attributes;

namespace ReseauEntreprise.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        public ActionResult Index()
        {
            IEnumerable<ListForm> AllEmployees = EmployeeService.GetAllActiveForAdmin()
                .Select(e => new ListForm()
                {
                    Id = (int) e.Employee_Id,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Email = e.Email,
                    Address = e.Address,
                    Phone = e.Phone,
                    RegNat = e.RegNat,
                    IsAdmin = (bool) e.IsAdmin
                });
            return View(AllEmployees);
        }

        public ActionResult Details(int id)
        {
            C.Employee e = EmployeeService.GetForAdmin(id);
            DetailsForm Details = new DetailsForm()
            {
                Id = (int) e.Employee_Id,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Email = e.Email,
                Address = e.Address,
                Phone = e.Phone,
                RegNat = e.RegNat,
                IsActif = e.Actif,
                IsAdmin = (bool) e.IsAdmin
            };
            Details.DepartmentHistory = DepartmentService.GetEmployeeDepartmentHistory(id).Select(tmp => new DepartmentForm()
            {
                Id = (int) tmp.Id,
                StartDate = tmp.StartDate,
                EndDate = tmp.EndDate,
                Name = tmp.Name,
                EmpId = id,
                DepId = tmp.DepId,
            });
            Details.StatusHistory = EmployeeService.GetEmployeeStatusHistory(id)
                .Select(tmp => new StatusForm()
                {
                    StatusName = tmp.Name,
                    StartDate = tmp.StartDate,
                    EndDate = tmp.EndDate
                });
            Details.ProjectManagerHistory = EmployeeService.GetEmployeeProjectManagerHistory(id)
                .Select(tmp => new ProjectManagerStatusForm()
                {
                    Project_Id = tmp.Project_Id,
                    ProjectName = tmp.Project_Name,
                    StartDate = tmp.StartDate,
                    EndDate = tmp.EndDate
                });
            return View(Details);
        }

        public ActionResult Delete(int id)
        {
            C.Employee emp = EmployeeService.Get(id);
            ListForm e = new ListForm()
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
        public ActionResult Delete(int id, ListForm HiddenForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (HiddenForm.Id == id)
                    {
                        C.Employee e = new C.Employee(HiddenForm.Id, HiddenForm.LastName, HiddenForm.FirstName, HiddenForm.Email, HiddenForm.Address, true, HiddenForm.RegNat, null, HiddenForm.Address, HiddenForm.Phone, HiddenForm.IsAdmin);
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
            }
            ViewBag.error = "Quelque chose ne va pas";
            return View();
        }

        public ActionResult Edit(int id)
        {
            try
            {
                C.Employee e = EmployeeService.GetForAdmin(id);
                if (!(e is null))
                {
                    EditForm form = new EditForm()
                    {
                        Id = id,
                        LastName = e.LastName,
                        FirstName = e.FirstName,
                        Email = e.Email,
                        Address = e.Address,
                        Phone = e.Phone,
                        RegNat = e.RegNat,
                        IsAdmin = (bool) e.IsAdmin
                    };

                    return View(form);
                }
            }
            catch (Exception exception)
            {
                throw (exception);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id, EditForm form)
        {
            if (ModelState.IsValid)
            {
                if (id == form.Id)
                {
                    C.Employee e = new C.Employee(form.Id, form.LastName, form.FirstName, form.Email, form.Password, true, form.RegNat, null, form.Address, form.Phone, form.IsAdmin);
                    try
                    {
                        if (EmployeeService.UpdateForAdmin(e))
                        {
                            return RedirectToAction("Index");
                        }
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
                                ModelState.AddModelError("RegNat", "Ce numero de régistre national est déjà utilisé.");
                            }
                        }
                    }
                }
            }
            return View(form);
        }
    }
}
