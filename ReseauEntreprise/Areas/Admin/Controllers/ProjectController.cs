﻿using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Admin.Models.ViewModels.Project;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Project;

namespace ReseauEntreprise.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            List<ListForm> list = new List<ListForm>();
            foreach (C.Project Project in ProjectService.GetAllActive())
            {
                int? ManagerId = Project.ProjectManagerId;
                C.Employee Manager = EmployeeService.Get((int)ManagerId);
                C.Employee Creator = EmployeeService.Get(Project.CreatorId);
                ListForm form = new ListForm(Project, Manager, Creator);
                list.Add(form);
            }
            return View(list);
        }
        public ActionResult History()
        {
            return View();
        }

        public ActionResult Create()
        {
            CreateForm form = new CreateForm
            {
                StartDate = DateTime.Today
            };
            IEnumerable<C.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> ManagerCandidates = new List<SelectListItem>();
            foreach (C.Employee emp in Employees)
            {
                ManagerCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            form.ProjectManagerCandidateList = ManagerCandidates;

            return View(form);
        }

        [HttpPost]
        public ActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                C.Project p = new C.Project( form.Name, form.Description, form.StartDate, form.EndDate, SessionUser.GetUser().Id, form.SelectedProjectManagerId);
                int ProjectManagerId = form.SelectedProjectManagerId;
                try
                {
                    if (ProjectService.Create(p, ProjectManagerId) != null)
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
            List<SelectListItem> ManagerCandidates = new List<SelectListItem>();
            foreach (C.Employee emp in Employees)
            {
                ManagerCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            
            form.ProjectManagerCandidateList = ManagerCandidates;
            return View(form);
        }


        public ActionResult Edit(int projectId)
        {
            C.Project project = ProjectService.GetProjectById(projectId);
            C.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(projectId));
            EditForm form = new EditForm()
            {
                Id = (int) project.Id,
                Name = project.Title,
                Description = project.Description,
                ProjectManagerId = (int) Manager.Employee_Id,
                SelectedProjectManagerId = (int) Manager.Employee_Id,
                StartDate = project.Start,
                EndDate = project.End,
                CreatorId = project.CreatorId
            };
            IEnumerable<C.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> ManagerCandidates = new List<SelectListItem>();
            foreach (C.Employee emp in Employees)
            {
                ManagerCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            if (!Employees.Any(emp => emp.Employee_Id == Manager.Employee_Id))
            {
                ManagerCandidates.Add(new SelectListItem()
                {
                    Text = "!!!VIRÉ!!! " + Manager.FirstName + " " + Manager.LastName + " (" + Manager.Email + ")",
                    Value = Manager.Employee_Id.ToString()
                });
            }
            form.ProjectManagerCandidateList = ManagerCandidates;

            return View(form);
        }

        [HttpPost]
        public ActionResult Edit(EditForm form)
        {
            if (ModelState.IsValid)
            {
                C.Project Project = new C.Project(form.Id, form.Name, form.Description, form.StartDate, form.EndDate, form.CreatorId, form.SelectedProjectManagerId);
                try
                {
                   if (ProjectService.Edit(SessionUser.GetUser().Id, Project))
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

            C.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(form.Id));
            IEnumerable<C.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> ManagerCandidates = new List<SelectListItem>();
            foreach (C.Employee emp in Employees)
            {
                ManagerCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            if (!Employees.Any(emp => emp.Employee_Id == Manager.Employee_Id))
            {
                ManagerCandidates.Add(new SelectListItem()
                {
                    Text = "!!!VIRÉ!!! " + Manager.FirstName + " " + Manager.LastName + " (" + Manager.Email + ")",
                    Value = Manager.Employee_Id.ToString()
                });
            }
            form.ProjectManagerCandidateList = ManagerCandidates;
            return View(form);
        }

        public ActionResult Delete(int projectId)
        {
            C.Project Project = ProjectService.GetProjectById(projectId);
            C.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(projectId));
            C.Employee Creator = EmployeeService.Get(Project.CreatorId);
            DeleteForm Form = new DeleteForm(Project, Manager, Creator);
            return View(Form);
        }

        [HttpPost]
        public ActionResult Delete(DeleteForm form)
        {
            if (ModelState.IsValid)
            {
                C.Project p = new C.Project(form.ProjectId, form.Name, form.Description, form.StartDate, form.EndDate, (int) form.Creator.Employee_Id, (int) form.ProjectManager.Employee_Id);
                try
                {
                    if (ProjectService.Delete(p, SessionUser.GetUser().Id))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Data.SqlClient.SqlException Exception)
                {
                    throw Exception;
                }
            }
            return View(form);
        }

        public ActionResult Details(int projectId)
        {

            C.Project Project = ProjectService.GetProjectById(projectId);
            C.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(projectId));
            C.Employee Creator = EmployeeService.Get(Project.CreatorId);
            IEnumerable<C.Team> Teams = ProjectService.GetAllTeamsForProject(projectId);
            DetailsForm Form = new DetailsForm
            {
                Id = (int) Project.Id,
                Name = Project.Title,
                Description = Project.Description,
                Manager = Manager,
                Creator = Creator,
                StartDate = Project.Start,
                EndDate = Project.End,
                Teams = Teams
            };

            return View(Form);
        }
    }
}