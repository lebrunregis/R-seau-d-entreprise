using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Project;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            int Employee_Id = SessionUser.GetUser().Id;
            List<ListForm> list = new List<ListForm>();
            foreach (C.Project Project in ProjectService.GetAllActive())
            {
                int? ManagerId = ProjectService.GetProjectManagerId((int)Project.Id);
                C.Employee Manager = EmployeeService.Get((int)ManagerId);
                ListForm form = new ListForm(Project, Manager, Employee_Id);
                list.Add(form);
            }
            return View(list);
        }

        public ActionResult History()
        {
            return View();
        }
        

        public ActionResult Details(int id)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            C.Project Project = ProjectService.GetProjectById(id);
            C.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(id));
            C.Employee Creator = EmployeeService.Get(Project.CreatorId);
            IEnumerable<C.Team> Teams = ProjectService.GetAllTeamsForProject(id);
            DetailsForm Form = new DetailsForm
            {
                Id = (int)Project.Id,
                Name = Project.Name,
                Description = Project.Description,
                Manager = Manager,
                Creator = Creator,
                StartDate = Project.Start,
                EndDate = Project.End,
                Teams = Teams,
                AmIProjectManager = (Employee_Id == Manager.Employee_Id)
            };

            return View(Form);
        }
    }
}