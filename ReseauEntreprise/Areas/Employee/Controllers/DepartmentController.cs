using Réseau_d_entreprise.Session.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Department;
using ED = ReseauEntreprise.Areas.Employee.Models.ViewModels.EmployeeDepartment;
using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class DepartmentController : Controller
    {
        // GET: Employee/Department
        public ActionResult Index()
        {
            List<ListForm> list = new List<ListForm>();
            foreach (C.Department Department in DepartmentService.GetAllActive())
            {
                ListForm form = new ListForm
                {
                    Id = (int)Department.Id,
                    Title = Department.Title,
                    Created = Department.Created,
                    Description = Department.Description
                };
                int? HeadOfDepartmentId = DepartmentService.GetHeadOfDepartmentId((int)Department.Id);
                if (HeadOfDepartmentId != null)
                {
                    form.HeadOfDepartment = EmployeeService.Get((int)HeadOfDepartmentId);
                }
                list.Add(form);
            }
            return View(list);
        }

        // GET: Employee/Department/Details/5
        public ActionResult Details(int id)
        {
            C.Department Department = DepartmentService.GetDepartmentById(id);
            DetailsForm form = new DetailsForm
            {
                Id = (int)Department.Id,
                Title = Department.Title,
                Created = Department.Created,
                Description = Department.Description,
                Creator = EmployeeService.Get(Department.Admin_Id),
                Active = Department.Active,
                Employees = DepartmentService.GetEmployeesForDepartment((int)Department.Id),
                Documents = DocumentService.GetForDepartment((int)Department.Id).Select(d => new Doc.ListForm { Name = d.Filename, Id = (int)d.Id })
            };
            int? HeadOfDepartmentId = DepartmentService.GetHeadOfDepartmentId((int)Department.Id);
            if (HeadOfDepartmentId != null)
            {
                form.HeadOfDepartment = EmployeeService.Get((int)HeadOfDepartmentId);
            }
            return View(form);
        }

        public ActionResult AddEmployeeToDepartment(int id)
        {
            int My_Id = SessionUser.GetUser().Id;
            IEnumerable<C.Department> MyDepartments = new List<C.Department>();
            if (AuthService.IsAdmin(My_Id))
            {
                MyDepartments = DepartmentService.GetAllActive();
            }
            else
            {
                MyDepartments = DepartmentService.GetHeadOfDepartmentActiveDepartments(My_Id);
            }
            if (!MyDepartments.Any())
            {
                return RedirectToAction("Index", "Employee");
            }
            IEnumerable<C.Department> EmpDepartments = DepartmentService.GetEmployeeDepartments(id);

            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            foreach (C.Department dep in MyDepartments)
            {
                if (!EmpDepartments.Any(empDep => empDep.Id == dep.Id))
                {
                    DepartmentList.Add(new SelectListItem
                    {
                        Text = dep.Title,
                        Value = dep.Id.ToString()
                    });
                }
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
                return RedirectToAction("Details", "Employee", new { id = form.SelectedEmployeeId });
            }
            return RedirectToAction("AddEmployeeToDepartment");
        }

        public ActionResult RemoveEmployeeFromDepartment(int id)
        {
            int My_Id = SessionUser.GetUser().Id;
            IEnumerable<C.Department> MyDepartments = new List<C.Department>();
            if (AuthService.IsAdmin(My_Id))
            {
                MyDepartments = DepartmentService.GetAllActive();
            }
            else
            {
                MyDepartments = DepartmentService.GetHeadOfDepartmentActiveDepartments(My_Id);
            }
            if (!MyDepartments.Any())
            {
                return RedirectToAction("Index", "Employee");
            }
            IEnumerable<C.Department> EmpDepartments = DepartmentService.GetEmployeeDepartments(id);
            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            foreach (C.Department dep in DepartmentService.GetEmployeeDepartments(id))
            {
                if (MyDepartments.Any(MyDep => MyDep.Id == dep.Id))
                {
                    DepartmentList.Add(new SelectListItem
                    {
                        Text = dep.Title,
                        Value = dep.Id.ToString()
                    });
                }
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
                return RedirectToAction("Details", "Employee", new {id = form.SelectedEmployeeId });
            }
            return RedirectToAction("RemoveEmployeeFromDepartment");
        }
    }
}
