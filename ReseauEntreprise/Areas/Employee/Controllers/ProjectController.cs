using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Project;
using TaskForm = ReseauEntreprise.Areas.Employee.Models.ViewModels.Task.ListForm;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;
using System.Linq;

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
                int ManagerId = Project.ProjectManagerId;
                C.Employee Manager = EmployeeService.Get(ManagerId);
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
            C.Employee Manager = EmployeeService.Get(Project.ProjectManagerId);
            C.Employee Creator = EmployeeService.Get(Project.CreatorId);
            IEnumerable<C.Team> Teams = ProjectService.GetAllTeamsForProject(projectId);
            IEnumerable<C.Task> Tasks = TaskService.GetForProject(projectId, Employee_Id);
            List<TaskForm> TasksForm = new List<TaskForm>();
            foreach (C.Task Task in Tasks)
            {
                TasksForm.Add(new TaskForm
                {
                    Id = Task.Id,
                    ProjectId = Task.ProjectId,
                    CreatorId = Task.CreatorId,
                    Name = Task.Title,
                    Description = Task.Description,
                    StartDate = Task.Start,
                    EndDate = Task.End,
                    Deadline = Task.Deadline,
                    SubtaskOf = Task.SubtaskOf,
                    StatusName = Task.StatusName,
                    StatusDate = Task.StatusDate,
                    StatusId = Task.StatusId,
                    TeamId = Task.TeamId,
                    Creator = EmployeeService.Get(Task.CreatorId),
                    TaskSubtaskOf = (Task.SubtaskOf != null) ? TaskService.Get        ((int)Task.SubtaskOf, SessionUser.GetUser().Id) : null,
                    Team          = (Task.TeamId    != null) ? TeamService.GetTeamById((int)Task.TeamId                             ) : null
                });
            }
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
                Tasks = TasksForm,
                
                IsProjectManager = (Employee_Id == Manager.Employee_Id),
                DiscScriptForm = new Models.ViewModels.Message.DiscussionScriptForm { ToProject = Project.Id },
                Documents = DocumentService.GetForProject((int)Project.Id).Select(d => new Doc.ListForm { Name = d.Filename, Id = (int)d.Id })
            };

            return View(Form);
        }
    }
}