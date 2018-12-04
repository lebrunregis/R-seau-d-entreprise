using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class TaskController : Controller
    {
        // GET: Employee/Task
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TeamTasks(int id)
        {
            return View();
        }

        public ActionResult AddProjectTask(int id)
        {
            return View();
        }

        public ActionResult AddSubtask(int id)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}