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
                    Name = Task.Name,
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
        public ActionResult ProjectTasks(int id)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            List<ListForm> list = new List<ListForm>();
            foreach (Task Task in TaskService.GetForProject(id, Employee_Id))
            {
                ListForm form = new ListForm()
                {
                    Id = Task.Id,
                    ProjectId = Task.ProjectId,
                    CreatorId = Task.CreatorId,
                    Name = Task.Name,
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
        public ActionResult TeamTasks(int id)
        {
            int Employee_Id = SessionUser.GetUser().Id;
            List<ListForm> list = new List<ListForm>();
            foreach (Task Task in TaskService.GetForTeam(id, Employee_Id))
            {
                ListForm form = new ListForm()
                {
                    Id = Task.Id,
                    ProjectId = Task.ProjectId,
                    CreatorId = Task.CreatorId,
                    Name = Task.Name,
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
        public ActionResult AddProjectTask(int id)
        {
            CreateForm form = new CreateForm
            {
                ProjectId = id,
                StartDate = DateTime.Today
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
                    Name = form.Name,
                    Description = form.Description,
                    StartDate = form.StartDate,
                    Deadline = form.Deadline,
                    SubtaskOf = null
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
            return RedirectToAction("Details","Project",new { id = form.ProjectId});
        }

        public ActionResult Edit(int id)
        {
            Task task = TaskService.Get(id, SessionUser.GetUser().Id);
            IEnumerable<TaskStatus> Statuses = TaskService.GetStatusList();
            EditForm form = new EditForm()
            {
                Id = (int)task.Id,
                ProjectId = (int)task.ProjectId,
                CreatorId = (int)task.CreatorId,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Deadline = task.Deadline,
                SubtaskOf = task.SubtaskOf,
                StatusName = task.StatusName,
                StatusDate = (DateTime)task.StatusDate,
                StatusId = (int)task.StatusId,
                SelectedStatusId = (int)task.StatusId

            };

            return View(form);
        }

        [HttpPost]
        public ActionResult Edit(EditForm form)
        {
            if (ModelState.IsValid)
            {
                Task Task = new Task();
                try
                {
                    if (TaskService.Edit(Task, SessionUser.GetUser().Id))
                    {
                        if (form.StatusId != form.SelectedStatusId)
                        {
                            TaskService.SetStatus(Task, form.SelectedStatusId, SessionUser.GetUser().Id);
                        }
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
            }
            return RedirectToAction("Details", "Project", new { id = form.ProjectId });
        }

        [TeamMemberRequired]
        public ActionResult AddSubtask(int id)
        {
            Task Parent = TaskService.Get(id, SessionUser.GetUser().Id);
            CreateForm form = new CreateForm
            {
                ProjectId = Parent.ProjectId,
                SubtaskOf = id,
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
                    Name = form.Name,
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
            return RedirectToAction("Details", "Project", new { id = form.ProjectId });
        }
        [TeamMemberRequired]
        public ActionResult Details(int id)
        {
            Task Task = TaskService.Get(id, SessionUser.GetUser().Id);
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
                Name = Task.Name,
                ProjectId = Task.ProjectId,
                CreatorId = Task.CreatorId,
                Description = Task.Description,
                StartDate = Task.StartDate,
                EndDate = Task.EndDate,
                Deadline = Task.Deadline,
                StatusName = Task.StatusName,
                StatusDate = (DateTime)Task.StatusDate,
                StatusId = (int)Task.StatusId
            };
            return View(form);
        }
    }
}