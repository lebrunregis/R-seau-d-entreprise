using C = Model.Client.Data;
using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Employee;
using Réseau_d_entreprise.Session.Attributes;
using Réseau_d_entreprise.Session;
using ProjectTeamsForm = ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage.ProjectTeamsForm;

namespace ReseauEntreprise.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class EmployeeController : Controller
    {
        public ActionResult Details(int id)
        {
            int My_Id = SessionUser.GetUser().Id;
            C.Employee e = EmployeeService.GetForAdmin(id);
            DetailsForm Details = new DetailsForm()
            {
                Id = id,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Email = e.Email,
                Address = e.Address,
                Phone = e.Phone,
                RegNat = e.RegNat,
                IsActif = e.Actif,
                IsAdmin = (bool)e.IsAdmin,
                IsMe = (e.Employee_Id == My_Id),
                Teams = TeamService.GetAllActiveTeamsForEmployee(id),
                Departments = DepartmentService.GetEmployeeActiveDepartments(id),
                TeamLeaderTeams = TeamService.GetActiveTeamsForTeamLeader(id),
                ProjectManagerProjects = ProjectService.GetActiveProjectsForManager(id),
                HeadOfDepartmentDepartments = DepartmentService.GetHeadOfDepartmentActiveDepartments(id)
            };

            IEnumerable<C.Department> MyDepartments = new List<C.Department>();
            if (AuthService.IsAdmin(My_Id))
            {
                MyDepartments = DepartmentService.GetAllActive();
            }
            else
            {
                MyDepartments = DepartmentService.GetHeadOfDepartmentActiveDepartments(My_Id);
            }
            IEnumerable<C.Department> EmpDepartments = DepartmentService.GetEmployeeDepartments(id);
            var intersec = from MyDep in MyDepartments
                    join EmpDep in EmpDepartments on MyDep.Id equals EmpDep.Id
                    select new { };
            if (intersec.Any())
            {
                Details.CanIRemoveFromDepartment = true;
            }

            if(MyDepartments.Except(EmpDepartments, new DepartmentComparator()).Any())
            {
                Details.CanIAddToDepartment = true;
            }
            

            return View(Details);
        }
        public ActionResult Index()
        {
            int My_Id = SessionUser.GetUser().Id;
            IEnumerable<ListForm> FormList = EmployeeService.GetAllActive().Select(emp => new ListForm
            {
                IsMe = (emp.Employee_Id == My_Id),
                Id = (int)emp.Employee_Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Departments = DepartmentService.GetEmployeeActiveDepartments(((int)emp.Employee_Id),
                TeamsInCommon = TeamService.GetActiveTeamsInCommon(int)emp.Employee_Id, My_Id).GroupBy(team => (int)team.Project_Id).Select(teamsGroup => new ProjectTeamsForm
                {
                    Project = ProjectService.GetProjectById(teamsGroup.Key),
                    Teams = teamsGroup.ToList()
                })
            }
            );
            return View(FormList);
        }
    }
}
