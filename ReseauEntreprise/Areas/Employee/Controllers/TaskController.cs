using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Task;
using Model.Client.Data;
using Model.Client.Service;
using ReseauEntreprise.Session.Attributes;

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
                    StartDate = Task.StartDate,
                    EndDate = Task.EndDate,
                    Deadline = Task.Deadline,
                    SubtaskOf = Task.SubtaskOf,
                    StatusName = Task.StatusName,
                    StatusDate = Task.StatusDate,
                    StatusId = Task.StatusId,
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
                    StartDate = Task.StartDate,
                    EndDate = Task.EndDate,
                    Deadline = Task.Deadline,
                    SubtaskOf = Task.SubtaskOf,
                    StatusName = Task.StatusName,
                    StatusDate = Task.StatusDate,
                    StatusId = Task.StatusId,
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
                    StartDate = Task.StartDate,
                    EndDate = Task.EndDate,
                    Deadline = Task.Deadline,
                    SubtaskOf = Task.SubtaskOf,
                    StatusName = Task.StatusName,
                    StatusDate = Task.StatusDate,
                    StatusId = Task.StatusId,
                };
                list.Add(form);
            }
            return View(list);
        }

        [ProjectManagerRequired]
        public ActionResult AddProjectTask(int projectId)
        {
            IEnumerable<Team> Teams = ProjectService.GetAllTeamsForProject(projectId);
            List<SelectListItem> TeamList = new List<SelectListItem>();
            foreach (Team Team in Teams)
            {
                TeamList.Add(new SelectListItem
                {
                    Text = Team.Name,
                    Value = Team.Id.ToString()
                });
            }
            CreateForm form = new CreateForm
            {
                ProjectId = projectId,
                StartDate = DateTime.Today,
                TeamList = TeamList
            };

            return View(form);
        }
        [ProjectManagerRequired]
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
                    StartDate = form.StartDate,
                    Deadline = form.Deadline,
                    SubtaskOf = null
                };
                try
                {
                    if (TaskService.Create(t, SessionUser.GetUser().Id) != null)
                    {
                        return RedirectToAction("Details", "Project", new { projectId = form.ProjectId });
                    }
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
            }
            return RedirectToAction("Details", "Project", new { projectId = form.ProjectId });
        }

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
                TeamId = (int)task.TeamId,
                Name = task.Title,
                Description = task.Description,
                StartDate = task.StartDate,
                Deadline = task.Deadline,
                SubtaskOf = task.SubtaskOf,
                SelectedStatusId = (int)task.StatusId,
                StatusList = StatusList
            };

            return View(form);
        }

        [HttpPost]
        public ActionResult Edit(EditForm form)
        {
            if (ModelState.IsValid)
            {

                Task Task = TaskService.Get(form.Id, SessionUser.GetUser().Id);
                Task.Title = form.Name;
                Task.Description = form.Description;
                Task.StartDate = form.StartDate;
                Task.Deadline = form.Deadline;
                Task.TeamId = form.TeamId;

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
                    StartDate = form.StartDate,
                    Deadline = form.Deadline,
                    SubtaskOf = form.SubtaskOf
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
            return RedirectToAction("Details", "Project", new { projectId = form.ProjectId });
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
            DetailsForm form = new DetailsForm()
            {
                Subtasks = Subtasks,
                Parent = Parent,
                Id = (int)Task.Id,
                Name = Task.Title,
                ProjectId = Task.ProjectId,
                CreatorId = Task.CreatorId,
                Description = Task.Description,
                StartDate = Task.StartDate,
                EndDate = Task.EndDate,
                Deadline = Task.Deadline,
                StatusName = Task.StatusName,
                StatusDate = (DateTime)Task.StatusDate,
                StatusId = (int)Task.StatusId,
                DiscScriptForm = new Models.ViewModels.Message.DiscussionScriptForm { ToTask = Task.Id }
            };
            return View(form);
        }
    }
}