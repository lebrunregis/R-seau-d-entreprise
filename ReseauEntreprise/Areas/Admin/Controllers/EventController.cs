using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G = Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Admin.Models.ViewModels.Event;
using Réseau_d_entreprise.Session.Attributes;

namespace ReseauEntreprise.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [AdminRequired]
    public class EventController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<ListForm> Events = EventService.GetAllActive()
                .Select(e => new ListForm()
                {
                    Id = e.Id,
                    DepartmentId = e.DepartmentId,
                    Name = e.Name,
                    Description = e.Description,
                    Address = e.Address,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                });
            return View(Events);
        }

        public ActionResult Create()
        {
            List<SelectListItem> DepartmentList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Toute l'entreprise",
                    Value = "-1"
                }
            };

            foreach (G.Department dep in DepartmentService.GetAllActive())
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = dep.Title,
                    Value = dep.Id.ToString()
                });
            }
            CreateForm form = new CreateForm
            {
                DepartmentList = DepartmentList,
                SelectedDepartmentId = -1
               
            };
            return View(form);

        }

        [HttpPost]
        public ActionResult Create(CreateForm Form)
        {
            if (ModelState.IsValid)
            {
                if (Form.SelectedDepartmentId == -1)
                {
                    Form.SelectedDepartmentId = null;
                }
                EventService.Create(new G.Event
                {
                    CreatorId = SessionUser.GetUser().Id,
                    DepartmentId = Form.SelectedDepartmentId,
                    Name = Form.Name,
                    Description = Form.Description,
                    Address = Form.Address,
                    StartDate = Form.StartDate,
                    EndDate = Form.EndDate.AddHours(24),
                    Open = Form.OpenEvent
                }, SessionUser.GetUser().Id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            G.Event Event = EventService.Get(id);
            List<SelectListItem> DepartmentList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Toute l'entreprise",
                    Value = "-1"
                }
            };

            foreach (G.Department dep in DepartmentService.GetAllActive())
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = dep.Title,
                    Value = dep.Id.ToString()
                });
            }
            EditForm form = new EditForm
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.StartDate,
                EndDate = Event.EndDate.AddHours(24),
                OpenEvent = Event.Open,
                DepartmentList = DepartmentList,
                SelectedDepartmentId = Event.DepartmentId
            };
            return View(form);
        }

        [HttpPost]
        public ActionResult Edit(EditForm Form)
        {
            if (ModelState.IsValid)
            {
                if (Form.SelectedDepartmentId == -1)
                {
                    Form.SelectedDepartmentId = null;
                }
                EventService.Edit(new G.Event
                {
                    Id = Form.Id,
                    DepartmentId = Form.SelectedDepartmentId,
                    Name = Form.Name,
                    Description = Form.Description,
                    Address = Form.Address,
                    StartDate = Form.StartDate,
                    EndDate = Form.EndDate,
                    Open = Form.OpenEvent
                }, SessionUser.GetUser().Id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            G.Event Event = EventService.Get(id);
            DeleteForm form = new DeleteForm
            {
                Id = Event.Id,
                CreatorId = Event.CreatorId,
                Name = Event.Name,
                Description = Event.Description,
                DepartmentId = Event.DepartmentId,
                Address = Event.Address,
                StartDate = Event.StartDate,
                EndDate = Event.EndDate,
                CreationDate = Event.CreationDate
            };
            return View(form);
        }

        [HttpPost]
        public ActionResult Delete(DeleteForm form)
        {
            G.Event e = new G.Event()
                {
                    Id = form.Id,
                    Name = form.Name,
                    Address = form.Address,
                    Description = form.Description,
                    CreatorId = form.CreatorId,
                    DepartmentId = form.DepartmentId,
                    StartDate = form.StartDate,
                    EndDate = form.EndDate
                };
                try
                {
                    EventService.Delete(e, SessionUser.GetUser().Id);
                }
                catch (System.Data.SqlClient.SqlException Exception)
                {
                    throw Exception;
                }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            G.Event Event = EventService.Get(id);
            DetailsForm form = new DetailsForm
            {
                Id = Event.Id,
                CreatorId = Event.CreatorId,
                Name = Event.Name,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.StartDate,
                EndDate = Event.EndDate,
                CreationDate = Event.CreationDate
            };
            return View(form);
        }

        public ActionResult SubscribeEmployees(int id)
        {
            IEnumerable<G.Employee> Employees = EmployeeService.GetAllActive();
            List<EmployeeSelectorForm> EmployeesForm = new List<EmployeeSelectorForm>();
            foreach (G.Employee e in Employees)
            {
                EmployeesForm.Add(new EmployeeSelectorForm
                {
                    Id = e.Employee_Id,
                    Identifier = e.FirstName + " " + e.LastName + " " + e.Email,
                    Selected = false
                });
            }

            G.Event Event = EventService.Get(id);
            DetailsForm EventForm = new DetailsForm
            {
                Id = Event.Id,
                CreatorId = Event.CreatorId,
                Name = Event.Name,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.StartDate,
                EndDate = Event.EndDate,
                CreationDate = Event.CreationDate
            };
            SubscribeListForm form = new SubscribeListForm
            {
                List = EmployeesForm,
                Event = EventForm
            };
            return View(form);
        }

        public ActionResult ConfirmSubscription(int id)
        {
            G.Event Event = EventService.Get(id);
            DetailsForm Form = new DetailsForm
            {
                Id = Event.Id,
                CreatorId = Event.CreatorId,
                DepartmentId = Event.DepartmentId,
                Name = Event.Name,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.StartDate,
                EndDate = Event.EndDate
            };

            return View();
        }

        [HttpPost]
        public ActionResult ConfirmSubscription(DetailsForm Form)
        {

            EventService.Participate(Form.Id, SessionUser.GetUser().Id);
            return View();
        }

        public ActionResult Attendance(int id)
        {
            EventService.Get(id);
            return View();
        }

        public ActionResult CancelSubscription(int id)
        {
            EventService.Get(id);
            return View();
        }
    }
}