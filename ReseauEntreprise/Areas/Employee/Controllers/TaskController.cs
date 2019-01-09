using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Task;
using Model.Client.Data;
using Model.Client.Service;
using ReseauEntreprise.Session.Attributes;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;
using System.Linq;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class TaskController : Controller
    {
        // GET: Employee/Task
        public ActionResult Index()
        {
            int Employee_Id = SessionUser.GetUser().Id;
            List<ListForm> list = new List<ListForm>();
            foreach (Task Task in TaskService.GetForUser(Employee_Id))
            {
                ListForm form = new ListForm()
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
                    Project = ProjectService.GetProjectById(Task.ProjectId),
                    Creator = EmployeeService.Get(Task.CreatorId),
                    Team = (Task.TeamId != null) ? TeamService.GetTeamById((int)Task.TeamId) : null,
                    TaskSubtaskOf = (Task.SubtaskOf != null) ? TaskService.Get((int)Task.SubtaskOf, SessionUser.GetUser().Id) : null
                };
                list.Add(form);
            }
            return View(list);
        }

        [ProjectManagerRequired]
        public ActionResult ProjectTasks(int taskId)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            List<ListForm> list = new List<ListForm>();
            foreach (Task Task in TaskService.GetForProject(taskId, Employee_Id))
            {
                ListForm form = new ListForm()
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
                    TeamId = Task.TeamId
                };
                list.Add(form);
            }
            return View(list);
        }

        [TeamMemberRequired]
        public ActionResult TeamTasks(int taskId)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            List<ListForm> list = new List<ListForm>();
            foreach (Task Task in TaskService.GetForTeam(taskId, Employee_Id))
            {
                ListForm form = new ListForm()
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
                    TeamId = Task.TeamId
                };
                list.Add(form);
            }
            return View(list);
        }

        private List<SelectListItem> GenerateTeamList(int projectId)
        {
            IEnumerable<Team> Teams = ProjectService.GetAllTeamsForProject(projectId);
            List<SelectListItem> TeamList = new List<SelectListItem>();
            TeamList.Add(new SelectListItem
            {
                Text = "None",
                Value = "-1"
            });
            foreach (Team Team in Teams)
            {
                TeamList.Add(new SelectListItem
                {
                    Text = Team.Name,
                    Value = Team.Id.ToString()
                });
            }
            return TeamList;
        }

        [ProjectManagerRequired]
        public ActionResult AddProjectTask(int projectId)
        {
            List<SelectListItem> Teams = GenerateTeamList(projectId);
            CreateForm form = new CreateForm
            {
                ProjectId = projectId,
                StartDate = DateTime.Today,
                TeamList = Teams,
                Project = ProjectService.GetProjectById(projectId)
            };

            return View(form);
        }

        [HttpPost]
        public ActionResult AddProjectTask(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                Task t = new Task()
                {
                    ProjectId = form.ProjectId,
                    Title = form.Name,
                    Description = form.Description,
                    Start = form.StartDate,
                    Deadline = form.Deadline,
                    SubtaskOf = null
                };
                try
                {
                    int? taskId = TaskService.Create(t, SessionUser.GetUser().Id);
                    if (taskId != null)
                    {
                        return RedirectToAction("Details", "Task", new { projectId = form.ProjectId,taskId = (int)taskId });
                    }
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
            }
            return RedirectToAction("Details", "Project", new { projectId = form.ProjectId });
        }

        [TeamMemberRequired]
        public ActionResult Edit(int taskId)
        {
            Task task = TaskService.Get(taskId, SessionUser.GetUser().Id);
            IEnumerable<TaskStatus> Statuses = TaskService.GetStatusList();
            List<SelectListItem> StatusList = new List<SelectListItem>();
            foreach (TaskStatus Status in Statuses)
            {
                StatusList.Add(new SelectListItem
                {
                    Text = Status.Name,
                    Value = Status.Id.ToString()
                });
            }
            EditForm form = new EditForm()
            {
                Id = (int)task.Id,
                ProjectId = (int)task.ProjectId,
                CreatorId = (int)task.CreatorId,
                TeamId = task.TeamId,
                Name = task.Title,
                Description = task.Description,
                StartDate = task.Start,
                Deadline = task.Deadline,
                SubtaskOf = task.SubtaskOf,
                SelectedStatusId = (int)task.StatusId,
                StatusList = StatusList,
                Project = ProjectService.GetProjectById(task.ProjectId),
                Team          = (task.TeamId    != null) ? TeamService.GetTeamById((int)task.TeamId                             ) : null,
                TaskSubtaskOf = (task.SubtaskOf != null) ? TaskService.Get        ((int)task.SubtaskOf, SessionUser.GetUser().Id) : null

            };

            return View(form);
        }

        [TeamMemberRequired]
        [HttpPost]
        public ActionResult Edit(int taskId, EditForm form)
        {
            if (ModelState.IsValid)
            {
                Task Task = TaskService.Get(taskId, SessionUser.GetUser().Id);
                Task.Title = form.Name;
                Task.Description = form.Description;
                Task.Start = form.StartDate;
                Task.Deadline = form.Deadline;
                Task.TeamId = form.TeamId;
                if (form.SelectedStatusId >= 3)
                { 
                    //3 is the id number of done status
                    Task.End = DateTime.Now;
                }
                else
                {
                    Task.End = null;
                }

                TaskService.Edit(Task, SessionUser.GetUser().Id);

                if (Task.StatusId != form.SelectedStatusId)
                {
                    TaskService.SetStatus(Task, form.SelectedStatusId, SessionUser.GetUser().Id);
                }
            }
            return RedirectToAction("Details", "Project", new { projectId = form.ProjectId });
        }

        [TeamMemberRequired]
        public ActionResult AddSubtask(int taskId)
        {
            Task Parent = TaskService.Get(taskId, SessionUser.GetUser().Id);
            CreateForm form = new CreateForm
            {
                ProjectId = Parent.ProjectId,
                SubtaskOf = taskId,
                StartDate = DateTime.Today
            };

            if(Parent.TeamId!= null)
            {
                form.SelectedTeamId = (int)Parent.TeamId;
            }

            return View(form);
        }

        [HttpPost]
        public ActionResult AddSubtask(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                Task t = new Task()
                {
                    ProjectId = form.ProjectId,
                    Title = form.Name,
                    Description = form.Description,
                    Start = form.StartDate,
                    Deadline = form.Deadline,
                    SubtaskOf = form.SubtaskOf,
                    TeamId = form.SelectedTeamId
                };
                try
                {
                    if (TaskService.Create(t, SessionUser.GetUser().Id) != null)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
            }
            return RedirectToAction("Details", "Task", new { projectId = form.ProjectId,taskId = form.SubtaskOf });
        }

        [TeamMemberRequired]
        public ActionResult Details(int taskId)
        {
            Task Task = TaskService.Get(taskId, SessionUser.GetUser().Id);
            Task Parent = null;

            if (!(Task.SubtaskOf is null))
            {
                Parent = TaskService.Get((int)Task.SubtaskOf, SessionUser.GetUser().Id);
            }

            IEnumerable<Task> Subtasks = TaskService.GetSubtasks(Task, SessionUser.GetUser().Id);
            List<ListForm> TasksForm = new List<ListForm>();
            foreach (Task task in Subtasks)
            {
                TasksForm.Add(new ListForm
                {
                    Id = task.Id,
                    ProjectId = task.ProjectId,
                    CreatorId = task.CreatorId,
                    Name = task.Title,
                    Description = task.Description,
                    StartDate = task.Start,
                    EndDate = task.End,
                    Deadline = task.Deadline,
                    SubtaskOf = task.SubtaskOf,
                    StatusName = task.StatusName,
                    StatusDate = task.StatusDate,
                    StatusId = task.StatusId,
                    TeamId = task.TeamId,
                    Creator = EmployeeService.Get(task.CreatorId),
                    Team          = (task.TeamId    != null) ? TeamService.GetTeamById((int)task.TeamId                             ) : null,
                    TaskSubtaskOf = (task.SubtaskOf != null) ? TaskService.Get        ((int)task.SubtaskOf, SessionUser.GetUser().Id) : null
                });
            }
            DetailsForm form = new DetailsForm()
            {
                Subtasks = TasksForm,
                Parent = Parent,
                Id = (int)Task.Id,
                TeamId = Task.TeamId,
                Name = Task.Title,
                ProjectId = Task.ProjectId,
                CreatorId = Task.CreatorId,
                Description = Task.Description,
                StartDate = Task.Start,
                EndDate = Task.End,
                Deadline = Task.Deadline,
                StatusName = Task.StatusName,
                StatusDate = (DateTime)Task.StatusDate,
                StatusId = (int)Task.StatusId,
                DiscScriptForm = new Models.ViewModels.Message.DiscussionScriptForm { ToTask = Task.Id },
                Documents = DocumentService.GetForTask((int)Task.Id).Select(d => new Doc.ListForm { Name = d.Filename, Id = (int)d.Id }),
                Project = ProjectService.GetProjectById(Task.ProjectId),
                Creator = EmployeeService.Get(Task.CreatorId),
                Team = (Task.TeamId != null) ? TeamService.GetTeamById((int)Task.TeamId) : null
            };

            return View(form);
        }
    }
}