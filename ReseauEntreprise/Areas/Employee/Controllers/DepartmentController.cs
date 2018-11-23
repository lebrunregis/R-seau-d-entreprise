using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Department;
using ED = ReseauEntreprise.Areas.Employee.Models.ViewModels.EmployeeDepartment;
using G = Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Session;

namespace ReseauEntreprise.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class DepartmentController : Controller
    {
        // GET: Admin/Department
        public ActionResult Index()
        {
            List<ListForm> list = new List<ListForm>();
            foreach (G.Department Department in DepartmentService.GetAll())
            {
                ListForm form = new ListForm
                {
                    Id = Department.Id,
                    Title = Department.Title,
                    Created = Department.Created,
                    Description = Department.Description,
                    Admin_Id = Department.Admin_Id,
                    Admin = null,
                    Active = Department.Active,
                };
                list.Add(form);
            }
            return View(list);
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int id)
        {
            G.Department Department = DepartmentService.GetDepartmentById(id);
            DetailsForm form = new DetailsForm
            {
                Id = Department.Id,
                Title = Department.Title,
                Created = Department.Created,
                Description = Department.Description,
                Admin_Id = Department.Admin_Id,
                Admin = null,
                Active = Department.Active,
            };
            return View(form);
        }

        // GET: Admin/Department/Edit/5
        public ActionResult Edit(int id)
        {
            G.Department Department = DepartmentService.GetDepartmentById(id);
            EditForm form = new EditForm
            {
                Id = Department.Id,
                Title = Department.Title,
                Created = Department.Created,
                Description = Department.Description,
                Admin_Id = Department.Admin_Id,
                Admin = null,
                Active = Department.Active,
            };
            return View(form);
        }

        // POST: Admin/Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditForm form)
        {
            if (ModelState.IsValid)
            {
                G.Department Department = new G.Department
                {
                    Id = form.Id,
                    Title = form.Title,
                    Description = form.Description,
                    Active = form.Active
                };
                try
                {
                    DepartmentService.Edit(SessionUser.GetUser().Id, Department);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }



        public ActionResult AddEmployeeToDepartment(int id)
        {
            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            foreach (G.Department dep in DepartmentService.GetAllActive())
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = dep.Title,
                    Value = dep.Id.ToString()
                });
            }
            ED.AddEmployeeToDepartmentForm form = new ED.AddEmployeeToDepartmentForm
            {
                SelectedEmployeeId = id,
                DepartmentList = DepartmentList
            };
            return View(form);
        }

        [HttpPost]
        public ActionResult AddEmployeeToDepartment(ED.AddEmployeeToDepartmentForm form)
        {
            if (ModelState.IsValid)
            {
                    DepartmentService.AddEmployeeDepartment(form.SelectedEmployeeId, form.SelectedDepartmentId);   
            }
            return RedirectToAction("Index","Employee");
        }

        public ActionResult RemoveEmployeeFromDepartment(int id)
        {
            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            foreach (G.Department dep in DepartmentService.GetEmployeeDepartments(id))
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = dep.Title,
                    Value = dep.Id.ToString()
                });
            }
            ED.RemoveEmployeeFromDepartmentForm form = new ED.RemoveEmployeeFromDepartmentForm
            {
                SelectedEmployeeId = id,
                DepartmentList = DepartmentList
            };

            return View(form);
        }

        [HttpPost]
        public ActionResult RemoveEmployeeFromDepartment(ED.RemoveEmployeeFromDepartmentForm form)
        {
            if (ModelState.IsValid)
            {
                    DepartmentService.RemoveEmployeeDepartment(form.SelectedEmployeeId, form.SelectedDepartmentId);       
            }
            return RedirectToAction("Index", "Employee");
        }
    }
}
