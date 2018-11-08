using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Department;
using G = Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Session;

namespace ReseauEntreprise.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
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

        // GET: Admin/Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Department/Create
        [HttpPost]
        public ActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                G.Department Department = new G.Department
                {
                    Title = form.Title,
                    Description = form.Description
                };

                    DepartmentService.Create(Department, SessionUser.GetUser().Id);
                    return RedirectToAction("Index");
            }
            return View();
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

        // GET: Admin/Department/Delete/5
        public ActionResult Delete(int id)
        {
            G.Department Department = DepartmentService.GetDepartmentById(id);
            DeleteForm form = new DeleteForm
            {
                Id = Department.Id,
                Title = Department.Title,
                Created = Department.Created,
                Description = Department.Description,
                Admin_Id = Department.Admin_Id,
                Admin = null
            };
            return View(form);
        }

        // POST: Admin/Department/Delete/5
        [HttpPost]
        public ActionResult Delete(DeleteForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
    }
}
