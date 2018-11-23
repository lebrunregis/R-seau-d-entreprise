using Model.Global.Service;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D = Model.Global.Data;

namespace ReseauEntreprise.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class HomeController : Controller
    {
        [EmployeeRequired]
        public ActionResult Index()
        {
            int Employee_Id = SessionUser.GetUser().Id;
            IEnumerable<D.Team> Teams = TeamService.GetAllActiveTeamsForEmployee(Employee_Id);
            List<ProjectTeams> ProjectTeamList = new List<ProjectTeams>();
            foreach(D.Team team in Teams)
            {
                ProjectTeams element = ProjectTeamList.Where(pt => pt.Project.Id == team.Project_Id).FirstOrDefault();
                if (element is null)
                {
                    ProjectTeams NewElement = new ProjectTeams
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
            IndexModel form = new IndexModel
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
    }
}