using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Project;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;

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
        

        public ActionResult Details(int projectId)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            C.Project Project = ProjectService.GetProjectById(projectId);
            C.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(projectId));
            C.Employee Creator = EmployeeService.Get(Project.CreatorId);
            IEnumerable<C.Team> Teams = ProjectService.GetAllTeamsForProject(projectId);
            IEnumerable<C.Task> Tasks = TaskService.GetForProject(projectId, Employee_Id);
            DetailsForm Form = new DetailsForm
            {
                Id = (int)Project.Id,
                Name = Project.Title,
                Description = Project.Description,
                Manager = Manager,
                Creator = Creator,
                StartDate = Project.Start,
                EndDate = Project.End,
                Teams = Teams,
                Tasks = Tasks,
                
                IsProjectManager = (Employee_Id == Manager.Employee_Id),
                DiscScriptForm = new Models.ViewModels.Message.DiscussionScriptForm { ToProject = Project.Id },
                Documents = DocumentService.GetForProject((int)Project.Id).Select(d => new Doc.ListForm { Name = d.Name, Id = (int)d.Id })
            };

            return View(Form);
        }
    }
}