using D = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.EmployeeTeam;
using ReseauEntreprise.Session.Attributes;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;


namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class TeamController : Controller
    {
        public ActionResult Index()
        {
            int Employee_Id = SessionUser.GetUser().Id;
            List<ListForm> list = new List<ListForm>();
            foreach (D.Team Team in TeamService.GetAllActiveTeamsForEmployee(Employee_Id))
            {
                int? TeamLeaderId = TeamService.GetTeamLeaderId((int)Team.Id);
                D.Employee TeamLeader = EmployeeService.Get((int)TeamLeaderId);
                D.Project Project = ProjectService.GetProjectById(Team.Project_Id);
                int? ProjectManagerId = ProjectService.GetProjectManagerId((int)Project.Id);
                D.Employee ProjectManager = EmployeeService.Get((int)ProjectManagerId);
                ListForm form = new ListForm
                {
                    TeamId = (int)Team.Id,
                    Name = Team.Name,
                    TeamLeader = TeamLeader,
                    ProjectManager = ProjectManager,
                    Project = Project,
                    CreationDate = Team.Created,
                    ProjectDeadLine = Project.End,
                    AmIPartOfTeam = true
                };
                list.Add(form);
            }

            foreach (D.Team Team in TeamService.GetActiveTeamsForTeamLeader(Employee_Id))
            {
                ListForm ThisTeam = list.FirstOrDefault(f => f.TeamId == Team.Id);
                if (ThisTeam != null)
                {
                    ThisTeam.AmITeamLeader = true;
                }
                else
                {
                    D.Employee TeamLeader = EmployeeService.Get(Employee_Id);
                    D.Project Project = ProjectService.GetProjectById(Team.Project_Id);
                    int? ProjectManagerId = ProjectService.GetProjectManagerId((int)Project.Id);
                    D.Employee ProjectManager = EmployeeService.Get((int)ProjectManagerId);
                    ListForm form = new ListForm
                    {
                        TeamId = (int)Team.Id,
                        Name = Team.Name,
                        TeamLeader = TeamLeader,
                        ProjectManager = ProjectManager,
                        Project = Project,
                        CreationDate = Team.Created,
                        ProjectDeadLine = Project.End,
                        AmITeamLeader = true
                    };
                    list.Add(form);
                }
            }
            foreach (D.Project Project in ProjectService.GetActiveProjectsForManager(Employee_Id))
            {
                foreach (D.Team Team in ProjectService.GetAllTeamsForProject((int)Project.Id))
                {
                    ListForm ThisTeam = list.FirstOrDefault(f => f.TeamId == Team.Id);
                    if (ThisTeam != null)
                    {
                        ThisTeam.AmIProjectManager = true;
                    }
                    else
                    {
                        int? TeamLeaderId = TeamService.GetTeamLeaderId((int)Team.Id);
                        D.Employee TeamLeader = EmployeeService.Get((int)TeamLeaderId);
                        D.Employee ProjectManager = EmployeeService.Get(Employee_Id);
                        ListForm form = new ListForm
                        {
                            TeamId = (int)Team.Id,
                            Name = Team.Name,
                            TeamLeader = TeamLeader,
                            ProjectManager = ProjectManager,
                            Project = Project,
                            CreationDate = Team.Created,
                            ProjectDeadLine = Project.End,
                            AmIProjectManager = true
                        };
                        list.Add(form);
                    }
                }
            }
            return View(list);
        }

        [ProjectManagerRequired]
        public ActionResult Create(int? Project_Id)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            IEnumerable<D.Project> MyProjects = new List<D.Project>();
            if (AuthService.IsAdmin(Employee_Id))
            {
                MyProjects = ProjectService.GetAllActive();
            }
            else
            {
                MyProjects = ProjectService.GetActiveProjectsForManager(Employee_Id);
            }
            if (MyProjects.Any())
            {
                CreateForm form = new CreateForm();
                IEnumerable<D.Employee> Employees = EmployeeService.GetAllActive();
                List<SelectListItem> TeamLeaderCandidates = new List<SelectListItem>();
                foreach (D.Employee emp in Employees)
                {
                    TeamLeaderCandidates.Add(new SelectListItem()
                    {
                        Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                        Value = emp.Employee_Id.ToString()
                    });
                }
                form.TeamLeaderCandidateList = TeamLeaderCandidates;

                List<SelectListItem> ProjectCandidates = new List<SelectListItem>();
                foreach (D.Project p in MyProjects)
                {
                    ProjectCandidates.Add(new SelectListItem()
                    {
                        Text = p.Name,
                        Value = p.Id.ToString()
                    });
                }
                form.ProjectCandidateList = ProjectCandidates;
                if (!(Project_Id is null) && MyProjects.Any(project => project.Id == Project_Id))
                {
                    form.SelectedProjectId = (int)Project_Id;
                }

                return View(form);
            }
            return RedirectToAction("Index", "Home");
        }
        [ProjectManagerRequired]
        [HttpPost]
        public ActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                D.Team t = new D.Team(form.Name, SessionUser.GetUser().Id, form.SelectedProjectId);
                int TeamLeaderId = form.SelectedTeamLeaderId;
                try
                {
                    int? NewTeam_Id = TeamService.Create(t, TeamLeaderId);
                    if (NewTeam_Id != null)
                    {
                        return RedirectToAction("EmployeesInTeam", new { teamId = NewTeam_Id });
                    }
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
            }
            IEnumerable<D.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> TeamLeaderCandidates = new List<SelectListItem>();
            foreach (D.Employee emp in Employees)
            {
                TeamLeaderCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            form.TeamLeaderCandidateList = TeamLeaderCandidates;

            IEnumerable<D.Project> Projects = ProjectService.GetAllActive();
            List<SelectListItem> ProjectCandidates = new List<SelectListItem>();
            foreach (D.Project p in Projects)
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

        [ProjectManagerRequired]
        public ActionResult Edit(int teamId)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            D.Team Team = TeamService.GetTeamById(teamId);
            if (AuthService.IsAdmin(Employee_Id) || ProjectService.GetProjectManagerId(Team.Project_Id) == Employee_Id)
            {
                D.Employee TeamLeader = EmployeeService.Get((int)TeamService.GetTeamLeaderId(teamId));
                EditForm form = new EditForm()
                {
                    Id = (int)Team.Id,
                    Name = Team.Name,
                    SelectedTeamLeaderId = (int)TeamLeader.Employee_Id,
                    CreatorId = Team.Creator_Id
                };
                IEnumerable<D.Employee> Employees = EmployeeService.GetAllActive();
                List<SelectListItem> TeamLeaderCandidates = new List<SelectListItem>();
                foreach (D.Employee emp in Employees)
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
            return RedirectToAction("Index");
        }
        [ProjectManagerRequired]
        [HttpPost]
        public ActionResult Edit(int id, EditForm form)
        {
            if (ModelState.IsValid)
            {
                D.Team Team = new D.Team(form.Name, form.CreatorId, form.ProjectId);
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

        [ProjectManagerRequired]
        public ActionResult Delete(int teamId)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            D.Team Team = TeamService.GetTeamById(teamId);
            if (AuthService.IsAdmin(Employee_Id) || ProjectService.GetProjectManagerId(Team.Project_Id) == Employee_Id)
            {
                DeleteForm form = new DeleteForm()
                {
                    Team_Id = (int)Team.Id,
                    Name = Team.Name,
                    Created = Team.Created,
                    Creator_Id = Team.Creator_Id,
                    Project_Id = Team.Project_Id
                };
                return View(form);
            }
            return RedirectToAction("Index");
        }
        [ProjectManagerRequired]
        [HttpPost]
        public ActionResult Delete(int id, DeleteForm form)
        {
            if (ModelState.IsValid)
            {
                if (id == form.Team_Id)
                {
                    D.Team Team = new D.Team(form.Team_Id, form.Name, form.Created, null, form.Creator_Id, form.Project_Id, null);
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
        [TeamMemberRequired]
        public ActionResult Details(int teamId)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            D.Team Team = TeamService.GetTeamById(teamId);
            D.Employee TeamLeader = EmployeeService.Get((int)TeamService.GetTeamLeaderId(teamId));
            D.Employee Creator = EmployeeService.Get(Team.Creator_Id);
            D.Project Project = ProjectService.GetProjectById(Team.Project_Id);
            IEnumerable<D.Task> Tasks = TaskService.GetForTeam(teamId, Employee_Id);
            IEnumerable<D.Employee> Members = TeamService.GetAllEmployeesForTeam(teamId);
            DetailsForm Form = new DetailsForm
            {
                Id = (int)Team.Id,
                Name = Team.Name,
                TeamLeader = TeamLeader,
                Creator = Creator,
                Project = Project,
                DateCreated = Team.Created,
                EndDate = Team.Disbanded,
                Members = Members,
                DiscScriptForm = new Models.ViewModels.Message.DiscussionScriptForm { ToTeam = Team.Id },
                Tasks = Tasks,
                IsTeamLeader = (Employee_Id == TeamLeader.Employee_Id),
                IsProjectManagerOrAdmin = ((AuthService.IsAdmin(Employee_Id)) || (Employee_Id == ProjectService.GetProjectManagerId(Team.Project_Id))),
                Documents = DocumentService.GetForTeam((int)Team.Id).Select(d => new Doc.ListForm { Name = d.Name, Id = (int)d.Id })
            };
            return View(Form);
        }

        [TeamLeaderRequired]
        public ActionResult EmployeesInTeam(int teamId)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            D.Team Team = TeamService.GetTeamById(teamId);

            IEnumerable<D.Employee> Employees = EmployeeService.GetAllActive();
            IEnumerable<D.Employee> EmployeesInTeam = TeamService.GetAllEmployeesForTeam(teamId);
            List<EmployeeTeamSelector> EmployeesInTeamFormList = new List<EmployeeTeamSelector>();
            foreach (D.Employee employee in Employees)
            {
                IEnumerable<D.Department> departments = DepartmentService.GetEmployeeActiveDepartments((int)employee.Employee_Id);
                EmployeesInTeamFormList.Add(new EmployeeTeamSelector
                {
                    Team = Team,
                    Employee = employee,
                    Departments = departments,
                    IsInTeam = EmployeesInTeam.Any(x => x.Employee_Id == employee.Employee_Id)
            });
            }

            return View(EmployeesInTeamFormList);
        }

        [HttpPost]
        public ActionResult EmployeesInTeam(IEnumerable<EmployeeTeamSelector> forms)
        {
            bool IsInTeam;
            IEnumerable<D.Employee> EmployeesInTeam = TeamService.GetAllEmployeesForTeam((int)forms.First().Team.Id);

            foreach (EmployeeTeamSelector selector in forms)
            {
                IsInTeam = EmployeesInTeam.Any( x => x.Employee_Id == selector.Employee.Employee_Id);
                if (selector.IsInTeam && !IsInTeam)
                {
                    TeamService.AddEmployee((int)selector.Team.Id, (int)selector.Employee.Employee_Id, SessionUser.GetUser().Id);
                }
                else if (!selector.IsInTeam && IsInTeam)
                {
                    TeamService.RemoveEmployee((int)selector.Team.Id, (int)selector.Employee.Employee_Id, SessionUser.GetUser().Id);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
