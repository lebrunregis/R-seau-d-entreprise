using G = Model.Global.Data;
using Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Employee;
using Réseau_d_entreprise.Session.Attributes;
using Réseau_d_entreprise.Session;

namespace ReseauEntreprise.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class EmployeeController : Controller
    {
        public ActionResult Details(int id)
        {
            G.Employee e = EmployeeService.GetForAdmin(id);
            DetailsForm Details = new DetailsForm()
            {
                Id = e.Employee_Id,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Email = e.Email,
                Address = e.Address,
                Phone = e.Phone,
                RegNat = e.RegNat,
                IsAdmin = e.IsAdmin,
                IsMe = (e.Employee_Id == SessionUser.GetUser().Id),
                Teams = TeamService.GetAllActiveTeamsForEmployee(e.Employee_Id),
                Departments = DepartmentService.GetEmployeeActiveDepartments(e.Employee_Id),
                TeamLeaderTeams = TeamService.GetActiveTeamsForTeamLeader(e.Employee_Id),
                ProjectManagerProjects = ProjectService.GetActiveProjectsForManager(e.Employee_Id),
                HeadOfDepartmentDepartments = DepartmentService.GetHeadOfDepartmentActiveDepartments(e.Employee_Id)
            };
            
            return View(Details);
        }
    }
}
