using Model.Client.Service;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using D = Model.Client.Data;
using Model.Client.Data;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Calendar;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using Newtonsoft.Json;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            int Employee_Id = SessionUser.GetUser().Id;
            IEnumerable<D.Team> Teams = TeamService.GetAllActiveTeamsForEmployee(Employee_Id);
            List<ProjectTeamsForm> ProjectTeamList = new List<ProjectTeamsForm>();
            foreach (D.Team team in Teams)
            {
                ProjectTeamsForm element = ProjectTeamList.Where(pt => pt.Project.Id == team.Project_Id).FirstOrDefault();
                if (element is null)
                {
                    ProjectTeamsForm NewElement = new ProjectTeamsForm
                    {
                        Project = ProjectService.GetProjectById(team.Project_Id),
                        Teams = new List<D.Team>()
                    };
                    NewElement.Teams.Add(team);
                    ProjectTeamList.Add(NewElement);
                }
                else
                {
                    element.Teams.Add(team);
                }
            }
            IEnumerable<D.Department> MyDepartments = DepartmentService.GetEmployeeDepartments(Employee_Id);
            IndexForm form = new IndexForm
            {
                ProjectTeamList = ProjectTeamList,
                MyDepartments = DepartmentService.GetEmployeeActiveDepartments(Employee_Id),
                ProjectManagerProjects = ProjectService.GetActiveProjectsForManager(Employee_Id),
                TeamLeaderTeams = TeamService.GetActiveTeamsForTeamLeader(Employee_Id),
                HeadOfDepartmentDepartments = DepartmentService.GetHeadOfDepartmentActiveDepartments(Employee_Id)
            };
            return View(form);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calendar()
        {
            ViewBag.Message = "Your calendar page.";
            return View();
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Return Calendar Events")]
        public JsonResult CalendarEventFeed(string start, string end)
        {
            IEnumerable<Event> Events = EventService.GetAllActiveForUser(SessionUser.GetUser().Id);
            List<CalendarForm> Forms = new List<CalendarForm>();
            foreach (Event Event in Events)
            {
                Forms.Add(new CalendarForm
                {
                    Title = Event.Title,
                    Start = JsonConvert.SerializeObject(Event.Start),
                    End = JsonConvert.SerializeObject(Event.End),
                    Url = ""
                });
            }
            return Json(Forms, JsonRequestBehavior.AllowGet);
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Return Calendar Projects")]
        public JsonResult CalendarProjectFeed(string start, string end)
        {
            IEnumerable<Project> Projects = ProjectService.GetAllActive();
            List<CalendarForm> Forms = new List<CalendarForm>();
            foreach (Project Project in Projects)
            {
                Forms.Add(new CalendarForm
                {
                    Title = Project.Title,
                    Start = JsonConvert.SerializeObject(Project.Start),
                    End = Project.End is null ?
                    JsonConvert.SerializeObject(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))) :
                    JsonConvert.SerializeObject((DateTime)Project.End),
                    Url = ""
                });
            }
            return Json(Forms, JsonRequestBehavior.AllowGet);
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Return Calendar Tasks")]
        public JsonResult CalendarTaskFeed(string start, string end)
        {
            IEnumerable<Task> Tasks = TaskService.GetForUser(SessionUser.GetUser().Id);
            List<CalendarForm> Forms = new List<CalendarForm>();
            foreach (Task Task in Tasks)
            {
                Forms.Add(new CalendarForm
                {
                    Title = Task.Title,
                    Start = JsonConvert.SerializeObject(Task.Start),
                    End = Task.End is null ?
                    JsonConvert.SerializeObject(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))) :
                    JsonConvert.SerializeObject((DateTime)Task.End),
                    Url = ""
                });
            }
            return Json(Forms, JsonRequestBehavior.AllowGet);
        }
    }
}