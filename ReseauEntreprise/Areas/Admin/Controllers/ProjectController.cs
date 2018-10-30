using D = Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using Model.Global.Data;
using ReseauEntreprise.Admin.Models.ViewModels.Project;

namespace ReseauEntreprise.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
    public class ProjectController : Controller
    {
        public ActionResult CreateProject()
        {
            IEnumerable<D.Employee> AllEmployees = EmployeeService.GetAllActive();
            ViewData["AllEmployees"] = new SelectList(AllEmployees
                .Select(e => new { value = e.Employee_Id.ToString(), text = $"{e.FirstName} {e.LastName}" }),
                "value", "text");
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectForm form)
        {
            if (ModelState.IsValid)
            {
                D.Project p = new D.Project()
                {
                    Name = form.Name,
                    Description = form.Description,
                    Creator = SessionUser.GetUser().Id
                };
                int ProjectManagerId = form.ProjectManager;
                try
                {
                    if (ProjectService.Create(p, ProjectManagerId) != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
            }
            IEnumerable<D.Employee> AllEmployees = EmployeeService.GetAllActive();
            ViewData["AllEmployees"] = new SelectList(AllEmployees
                .Select(e => new { value = e.Employee_Id.ToString(), text = $"{e.FirstName} {e.LastName}" }),
                "value", "text");
            return View(form);
        }

        public ActionResult Index()
        {
            List<ListProjectForm> list = new List<ListProjectForm>();
            foreach (Project projet in ProjectService.GetAll())
            {
                ListProjectForm form = new ListProjectForm(projet);
                list.Add(form);
            }
            return View(list);
        }
        public ActionResult History()
        {
            return View();
        }
    }
}