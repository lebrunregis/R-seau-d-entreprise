using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.EmployeeTeam;

namespace ReseauEntreprise.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
    public class TeamController : Controller
    {
        // GET: Admin/Team
        public ActionResult Index()
        {
            List<ListForm> list = new List<ListForm>();
            foreach (C.Team Team in TeamService.GetAllActive())
            {
                int? TeamLeaderId = TeamService.GetTeamLeaderId((int)Team.Id);
                C.Employee TeamLeader = EmployeeService.Get((int)TeamLeaderId);
                C.Employee Creator = EmployeeService.Get(Team.Creator_Id);
                C.Project Project = ProjectService.GetProjectById(Team.Project_Id);
                ListForm form = new ListForm(Team, TeamLeader, Creator, Project);
                list.Add(form);
            }
            return View(list);
        }

        // GET: Admin/Team/Create
        public ActionResult Create()
        {
            CreateForm form = new CreateForm();
            IEnumerable<C.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> TeamLeaderCandidates = new List<SelectListItem>();
            foreach (C.Employee emp in Employees)
            {
                TeamLeaderCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            form.TeamLeaderCandidateList = TeamLeaderCandidates;

            IEnumerable<C.Project> Projects = ProjectService.GetAllActive();
            List<SelectListItem> ProjectCandidates = new List<SelectListItem>();
            foreach (C.Project p in Projects)
            {
                ProjectCandidates.Add(new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
            }
            form.ProjectCandidateList = ProjectCandidates;

            return View(form);
        }

        // POST: Admin/Team/Create
        [HttpPost]
        public ActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                C.Team t = new C.Team(-1, form.Name,DateTime.Now,null, SessionUser.GetUser().Id, form.SelectedProjectId,new List<C.Employee>());
                int TeamLeaderId = form.SelectedTeamLeaderId;
                try
                {
                    if (TeamService.Create(t, TeamLeaderId) != null)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
            }
            IEnumerable<C.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> TeamLeaderCandidates = new List<SelectListItem>();
            foreach (C.Employee emp in Employees)
            {
                TeamLeaderCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            form.TeamLeaderCandidateList = TeamLeaderCandidates;

            IEnumerable<C.Project> Projects = ProjectService.GetAllActive();
            List<SelectListItem> ProjectCandidates = new List<SelectListItem>();
            foreach (C.Project p in Projects)
            {
                ProjectCandidates.Add(new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
            }
            form.ProjectCandidateList = ProjectCandidates;
            return View(form);
        }

        // GET: Admin/Team/Edit/5
        public ActionResult Edit(int id)
        {
            C.Team Team = TeamService.GetTeamById(id);
            C.Employee TeamLeader = EmployeeService.Get((int)TeamService.GetTeamLeaderId(id));
            EditForm form = new EditForm()
            {
                Id = (int) Team.Id,
                Name = Team.Name,
                SelectedTeamLeaderId = (int) TeamLeader.Employee_Id,
                CreatorId = Team.Creator_Id
            };
            IEnumerable<C.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> TeamLeaderCandidates = new List<SelectListItem>();
            foreach (C.Employee emp in Employees)
            {
                TeamLeaderCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            // si le TeamLeader actuel est desactivé
            if (!Employees.Any(emp => emp.Employee_Id == TeamLeader.Employee_Id))
            {
                TeamLeaderCandidates.Add(new SelectListItem()
                {
                    Text = "!!!VIRÉ!!! " + TeamLeader.FirstName + " " + TeamLeader.LastName + " (" + TeamLeader.Email + ")",
                    Value = TeamLeader.Employee_Id.ToString()
                });
            }
            form.TeamLeaderCandidateList = TeamLeaderCandidates;

            return View(form);
        }

        // POST: Admin/Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditForm form)
        {
            if (ModelState.IsValid)
            {
                C.Team Team = new C.Team(form.Id, form.Name, form.Created, null, form.CreatorId, form.ProjectId,null);
                try
                {
                    if (TeamService.Edit(SessionUser.GetUser().Id, Team, form.SelectedTeamLeaderId))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
                return RedirectToAction("Edit");
            }
            return View(form);
        }

        // GET: Admin/Team/Delete/5
        public ActionResult Delete(int id)
        {
            C.Team Team = TeamService.GetTeamById(id);
            DeleteForm form = new DeleteForm()
            {
                Team_Id = (int) Team.Id,
                Name = Team.Name,
                Created = Team.Created,
                Creator_Id = Team.Creator_Id,
                Project_Id = Team.Project_Id
            };
            return View(form);
        }

        // POST: Admin/Team/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DeleteForm form)
        {
            if (ModelState.IsValid)
            {
                if (id == form.Team_Id)
                {
                    C.Team Team = new C.Team(form.Team_Id, form.Name, form.Created,null, form.Creator_Id, form.Project_Id,null);
                    try
                    {
                        if (TeamService.Delete(Team, SessionUser.GetUser().Id))
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    catch (System.Data.SqlClient.SqlException Exception)
                    {
                        throw Exception;
                    }
                }
            }
            return View(form);
        }
        public ActionResult Details(int id)
        {

            C.Team Team = TeamService.GetTeamById(id);
            C.Employee TeamLeader = EmployeeService.Get((int)TeamService.GetTeamLeaderId(id));
            C.Employee Creator = EmployeeService.Get(Team.Creator_Id);
            C.Project Project = ProjectService.GetProjectById(Team.Project_Id);
            IEnumerable<C.Employee> Members = TeamService.GetAllEmployeesForTeam(id);
            DetailsForm Form = new DetailsForm
            {
                Id = (int) Team.Id,
                Name = Team.Name,
                TeamLeader = TeamLeader,
                Creator = Creator,
                Project = Project,
                DateCreated = Team.Created,
                EndDate = Team.Disbanded,
                Members = Members
            };
            return View(Form);
        }

        public ActionResult EmployeesInTeam(int id)
        {
            //INSERER VERIFICATION EXISTANCE TEAM 
            IEnumerable<C.Employee> Employees = EmployeeService.GetAllActive();
            List<EmployeesInTeamForm> EmployeesInTeamFormList = new List<EmployeesInTeamForm>();
            foreach (C.Employee employee in Employees)
            {
                IEnumerable<C.Department> departments = DepartmentService.GetEmployeeDepartments((int) employee.Employee_Id);
                EmployeesInTeamFormList.Add(new EmployeesInTeamForm
                {
                    Employee =  employee,
                    Departments = departments,
                    IsInTeam = TeamService.IsInTeam(id, (int) employee.Employee_Id)
                });
            }
            return View(EmployeesInTeamFormList);
        }

        [HttpPost]
        public JsonResult EmployeesInTeam(int id, int EmployeeId, bool IsChecked)
        {
            if (IsChecked)
            {
                TeamService.AddEmployee(id, EmployeeId, SessionUser.GetUser().Id);
            }
            else
            {
                TeamService.RemoveEmployee(id, EmployeeId, SessionUser.GetUser().Id);
            }

            return new JsonResult
            {
                Data = TeamService.IsInTeam(id, EmployeeId)
            };
        }
    }
}
