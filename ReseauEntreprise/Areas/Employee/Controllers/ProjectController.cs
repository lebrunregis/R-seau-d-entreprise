using G = Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using Model.Global.Data;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Project;

namespace ReseauEntreprise.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            int Employee_Id = SessionUser.GetUser().Id;
            List<ListForm> list = new List<ListForm>();
            foreach (Project Project in ProjectService.GetAllActive())
            {
                int? ManagerId = ProjectService.GetProjectManagerId(Project.Id);
                G.Employee Manager = EmployeeService.Get((int)ManagerId);
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
            G.Project Project = ProjectService.GetProjectById(id);
            G.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(id));
            G.Employee Creator = EmployeeService.Get(Project.CreatorId);
            IEnumerable<G.Team> Teams = ProjectService.GetAllTeamsForProject(id);
            DetailsForm Form = new DetailsForm
            {
                Id = Project.Id,
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