using D = Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using Model.Global.Data;
using ReseauEntreprise.Admin.Models.ViewModels.Project;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Project;

namespace ReseauEntreprise.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            List<ListForm> list = new List<ListForm>();
            foreach (Project Project in ProjectService.GetAll())
            {
                int? ManagerId = ProjectService.GetProjectManagerId(Project.Id);
                D.Employee Manager = EmployeeService.Get((int)ManagerId);
                D.Employee Creator = EmployeeService.Get(Project.CreatorId);
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
            CreateForm form = new CreateForm();
            IEnumerable<D.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> ManagerCandidates = new List<SelectListItem>();
            foreach (D.Employee emp in Employees)
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
                D.Project p = new D.Project()
                {
                    Name = form.Name,
                    Description = form.Description,
                    CreatorId = SessionUser.GetUser().Id
                };
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
            IEnumerable<D.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> ManagerCandidates = new List<SelectListItem>();
            foreach (D.Employee emp in Employees)
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


        public ActionResult Edit(int id)
        {
            Project project = ProjectService.GetProjectById(id);
            D.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(id));
            EditForm form = new EditForm()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                ProjectManagerId = Manager.Employee_Id,
                StartDate = project.Start,
                EndDate = project.End,
                CreatorId = project.CreatorId
            };
            IEnumerable<D.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> ManagerCandidates = new List<SelectListItem>();
            foreach (D.Employee emp in Employees)
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
        public ActionResult Edit(EditForm form)
        {
            if (ModelState.IsValid)
            {
                D.Project Project = new D.Project()
                {
                    Id = form.Id,
                    Name = form.Name,
                    Description = form.Description,
                    Start = form.StartDate,
                    End = form.EndDate,
                    CreatorId = form.CreatorId,
                    ProjectManagerId = form.ProjectManagerId
                };
                try
                {
                    ProjectService.Edit(SessionUser.GetUser().Id, Project);
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    throw (exception);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            D.Project Project = ProjectService.GetProjectById(id);
            D.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(id));
            D.Employee Creator = EmployeeService.Get(Project.CreatorId);
            DeleteForm Form = new DeleteForm(Project, Manager, Creator);
            return View(Form);
        }

        [HttpPost]
        public ActionResult Delete(DeleteForm form)
        {
            if (ModelState.IsValid)
            {
                D.Project p = new D.Project()
                {
                    Id = form.ProjectId,
                    Name = form.Name,
                    Description = form.Description,
                    CreatorId = form.Creator.Employee_Id,
                    Start = form.StartDate,
                    End = form.EndDate 
                };
                try
                {
                    ProjectService.Delete(p, SessionUser.GetUser().Id);
                }
                catch (System.Data.SqlClient.SqlException Exception)
                {
                    throw Exception;
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            D.Project Project = ProjectService.GetProjectById(id);
            D.Employee Manager = EmployeeService.Get((int)ProjectService.GetProjectManagerId(id));
            D.Employee Creator = EmployeeService.Get(Project.CreatorId);
            DetailsForm Form = new DetailsForm
            {
                Id = Project.Id,
                Name = Project.Name,
                Description = Project.Description,
                Manager = Manager,
                StartDate = Project.Start,
                EndDate = Project.End
            };
            return View(Form);
        }
    }
}