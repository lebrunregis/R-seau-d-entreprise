using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Department;
using G = Model.Global.Data;
using Model.Global.Service;

namespace ReseauEntreprise.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
    public class DepartmentController : Controller
    {
        // GET: Admin/Department
        public ActionResult Index()
        {
        /*    List<Form> list = new List<Form>();
            foreach (G.Department Department in DepartmentService.GetAll())
            {
                int? ManagerId = ProjectService.GetProjectManagerId(Project.Id);
                D.Employee Manager = EmployeeService.Get((int)ManagerId);
                D.Employee Creator = EmployeeService.Get(Project.CreatorId);
                ListForm form = new ListForm(Project, Manager, Creator);
                list.Add(form);
            }*/
            return View();
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Department/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Department/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
