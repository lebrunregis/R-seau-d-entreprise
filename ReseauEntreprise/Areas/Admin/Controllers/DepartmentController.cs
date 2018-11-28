using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Department;
using ED = ReseauEntreprise.Areas.Admin.Models.ViewModels.EmployeeDepartment;
using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session;

namespace ReseauEntreprise.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
    public class DepartmentController : Controller
    {
        // GET: Admin/Department
        public ActionResult Index()
        {
            List<ListForm> list = new List<ListForm>();
            foreach (C.Department Department in DepartmentService.GetAll())
            {
                ListForm form = new ListForm
                {
                    Id = (int) Department.Id,
                    Title = Department.Title,
                    Created = Department.Created,
                    Description = Department.Description,
                    Admin_Id = Department.Admin_Id,
                    Admin = null,
                    Active = Department.Active,
                };
                list.Add(form);
            }
            return View(list);
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int id)
        {
            C.Department Department = DepartmentService.GetDepartmentById(id);
            DetailsForm form = new DetailsForm
            {
                Id = (int) Department.Id,
                Title = Department.Title,
                Created = Department.Created,
                Description = Department.Description,
                Admin_Id = Department.Admin_Id,
                Admin = EmployeeService.Get(Department.Admin_Id),
                Active = Department.Active,
                Employees = DepartmentService.GetEmployeesForDepartment(id)
            };
            int? HeadOfDepartmentId = DepartmentService.GetHeadOfDepartmentId(id);
            if (HeadOfDepartmentId != null)
            {
                form.HeadOfDepartment = EmployeeService.Get((int)HeadOfDepartmentId);
            }
            return View(form);
        }

        // GET: Admin/Department/Create
        public ActionResult Create()
        {
            CreateForm form = new CreateForm();
            IEnumerable<G.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> HeadOfDepartmentCandidates = new List<SelectListItem>();
            foreach (G.Employee emp in Employees)
            {
                HeadOfDepartmentCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }
            form.HeadOfDepartmentCandidateList = HeadOfDepartmentCandidates;
            return View(form);
        }

        // POST: Admin/Department/Create
        [HttpPost]
        public ActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                C.Department Department = new C.Department( form.Title, DateTime.Now, form.Description, SessionUser.GetUser().Id, true);

                int? DepId = DepartmentService.Create(Department, SessionUser.GetUser().Id);
                if (DepId != null)
                {
                    if (DepartmentService.ChangeHeadOfDepartment((int)DepId, form.SelectedHeadOfDepartmentId, SessionUser.GetUser().Id))
                    {
                        return RedirectToAction("Index");
                    }
                }
                IEnumerable<G.Employee> Employees = EmployeeService.GetAllActive();
                List<SelectListItem> HeadOfDepartmentCandidates = new List<SelectListItem>();
                foreach (G.Employee emp in Employees)
                {
                    HeadOfDepartmentCandidates.Add(new SelectListItem()
                    {
                        Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                        Value = emp.Employee_Id.ToString()
                    });
                }
                form.HeadOfDepartmentCandidateList = HeadOfDepartmentCandidates;
            }
            return View(form);
        }

        // GET: Admin/Department/Edit/5
        public ActionResult Edit(int id)
        {
            C.Department Department = DepartmentService.GetDepartmentById(id);
            EditForm form = new EditForm
            {
                Id = (int)Department.Id,
                Title = Department.Title,
                Created = Department.Created,
                Description = Department.Description,
                Admin_Id = Department.Admin_Id,
                Admin = null,
                Active = Department.Active,
            };

            IEnumerable<G.Employee> Employees = EmployeeService.GetAllActive();
            List<SelectListItem> HeadOfDepartmentCandidates = new List<SelectListItem>();
            foreach (G.Employee emp in Employees)
            {
                HeadOfDepartmentCandidates.Add(new SelectListItem()
                {
                    Text = emp.FirstName + " " + emp.LastName + " (" + emp.Email + ")",
                    Value = emp.Employee_Id.ToString()
                });
            }

            int? HeadOfDepId = DepartmentService.GetHeadOfDepartmentId(id);
            if (HeadOfDepId == null)
            {
                HeadOfDepartmentCandidates.Add(new SelectListItem()
                {
                    Text = "!!!NOT CHOSEN!!!",
                    Value = 0.ToString()
                });
                form.SelectedHeadOfDepartmentId = 0;
            }
            else
            {
                G.Employee HeadOfDepartment = EmployeeService.Get((int)HeadOfDepId);
                if (!Employees.Any(emp => emp.Employee_Id == HeadOfDepartment.Employee_Id))
                {
                    HeadOfDepartmentCandidates.Add(new SelectListItem()
                    {
                        Text = "!!!VIRÉ!!! " + HeadOfDepartment.FirstName + " " + HeadOfDepartment.LastName + " (" + HeadOfDepartment.Email + ")",
                        Value = HeadOfDepartment.Employee_Id.ToString()
                    });
                }
                form.SelectedHeadOfDepartmentId = HeadOfDepartment.Employee_Id;
            }
            form.HeadOfDepartmentCandidateList = HeadOfDepartmentCandidates;
            return View(form);
        }

        // POST: Admin/Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditForm form)
        {
            if (ModelState.IsValid)
            {
                C.Department Department = new C.Department(form.Id, form.Title, DateTime.Now, form.Description, SessionUser.GetUser().Id, form.Active);
                try
                {
                    if (DepartmentService.Edit(SessionUser.GetUser().Id, Department))
                    {
                        DepartmentService.ChangeHeadOfDepartment(id, form.SelectedHeadOfDepartmentId, SessionUser.GetUser().Id);
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    return View();
                }
                return RedirectToAction("Edit");
            }
            return View();
        }

        // GET: Admin/Department/Delete/5
        public ActionResult Delete(int id)
        {
            C.Department Department = DepartmentService.GetDepartmentById(id);
            DeleteForm form = new DeleteForm
            {
                Id = (int) Department.Id,
                Title = Department.Title,
                Created = Department.Created,
                Description = Department.Description,
                Admin_Id = Department.Admin_Id,
                Admin = null
            };
            return View(form);
        }

        // POST: Admin/Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DeleteForm form)
        {
            if (id == form.Id)
            {
                try
                {
                    DepartmentService.Delete(SessionUser.GetUser().Id, form.Id);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(form);
        }


        public ActionResult AddEmployeeToDepartment(int id)
        {
            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            foreach (C.Department dep in DepartmentService.GetAllActive())
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = dep.Title,
                    Value = dep.Id.ToString()
                });
            }
            ED.AddEmployeeToDepartmentForm form = new ED.AddEmployeeToDepartmentForm
            {
                SelectedEmployeeId = id,
                DepartmentList = DepartmentList
            };
            return View(form);
        }

        [HttpPost]
        public ActionResult AddEmployeeToDepartment(ED.AddEmployeeToDepartmentForm form)
        {
            if (ModelState.IsValid)
            {
                    DepartmentService.AddEmployeeDepartment(form.SelectedEmployeeId, form.SelectedDepartmentId, SessionUser.GetUser().Id);   
            }
            return RedirectToAction("Index","Employee");
        }

        public ActionResult RemoveEmployeeFromDepartment(int id)
        {
            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            foreach (C.Department dep in DepartmentService.GetEmployeeDepartments(id))
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = dep.Title,
                    Value = dep.Id.ToString()
                });
            }
            ED.RemoveEmployeeFromDepartmentForm form = new ED.RemoveEmployeeFromDepartmentForm
            {
                SelectedEmployeeId = id,
                DepartmentList = DepartmentList
            };

            return View(form);
        }

        [HttpPost]
        public ActionResult RemoveEmployeeFromDepartment(ED.RemoveEmployeeFromDepartmentForm form)
        {
            if (ModelState.IsValid)
            {
                    DepartmentService.RemoveEmployeeDepartment(form.SelectedEmployeeId, form.SelectedDepartmentId, SessionUser.GetUser().Id);       
            }
            return RedirectToAction("Index", "Employee");
        }
    }
}
