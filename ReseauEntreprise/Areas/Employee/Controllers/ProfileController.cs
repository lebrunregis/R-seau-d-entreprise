using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Employee/Profile
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Profile/Create
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

        // GET: Employee/Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Profile/Edit/5
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

        // GET: Employee/Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Profile/Delete/5
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
