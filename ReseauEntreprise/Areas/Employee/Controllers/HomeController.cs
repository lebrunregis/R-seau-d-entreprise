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
            ViewBag.Message = "Application description.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us.";

            return View();
        }

        public ActionResult AccessDenied()
        {
            ViewBag.Message = "Access Denied.";

            return View();
        }

        public ActionResult Calendar()
        {
            ViewBag.Message = "Calendar page.";
            return View();
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Return Calendar Events")]
        public ContentResult CalendarEventFeed(string start, string end)
        {
            JsonSerializerSettings config = new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd" };
            IEnumerable<Event> Events = EventService.GetAllActiveForUser(SessionUser.GetUser().Id);
            List<CalendarForm> Forms = new List<CalendarForm>();
            var urlHelper = new UrlHelper(HttpContext.Request.RequestContext);

            foreach (Event Event in Events)
            {
                Forms.Add(new CalendarForm
                {
                    Id = (int)Event.Id,
                    Title = Event.Title,
                    Start = Event.Start,
                    End = Event.End,
                    Url = urlHelper.Action("Details", "Event",new { id = Event.Id})
                });
            }
            return Content(JsonConvert.SerializeObject(Forms, Formatting.Indented, config), "application/json");
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Return Calendar Projects")]
        public ContentResult CalendarProjectFeed(string start, string end)
        {
            JsonSerializerSettings config = new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd" };
            IEnumerable<Project> Projects = ProjectService.GetAllActive();
            List<CalendarForm> Forms = new List<CalendarForm>();
            var urlHelper = new UrlHelper(HttpContext.Request.RequestContext);

            foreach (Project Project in Projects)
            {
                Forms.Add(new CalendarForm
                {
                    Id = (int)Project.Id,
                    Title = Project.Title,
                    Start = Project.Start,
                    End = Project.End is null ?
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) :
                    (DateTime)Project.End,
                    Url = urlHelper.Action("Details", "Project",new { projectId=Project.Id})
                });
            }
            return Content(JsonConvert.SerializeObject(Forms, Formatting.Indented, config), "application/json");
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Return Calendar Tasks")]
        public ContentResult CalendarTaskFeed(string start, string end)
        {
            JsonSerializerSettings config = new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd" };
            IEnumerable<Task> Tasks = TaskService.GetForUser(SessionUser.GetUser().Id);
            List<CalendarForm> Forms = new List<CalendarForm>();
            var urlHelper = new UrlHelper(HttpContext.Request.RequestContext);

            foreach (Task Task in Tasks)
            {
                Forms.Add(new CalendarForm
                {
                    Id = (int)Task.Id,
                    Title = Task.Title,
                    Start = Task.Start,
                    End = Task.End is null ? Task.Deadline is null ?
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) :
                    (DateTime)Task.Deadline :
                    (DateTime)Task.End,
                    Url = urlHelper.Action("Details", "Task",new {taskId = Task.Id })
                });
            }
            return Content(JsonConvert.SerializeObject(Forms, Formatting.Indented, config), "application/json");
        }
    }
}