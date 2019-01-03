using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C = Model.Client.Data;
using Model.Client.Service;
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
            List<ListForm> Events = EventService.GetAllActive()
                .Select(e => new ListForm()
                {
                    Id = (int)e.Id,
                    DepartmentId = e.DepartmentId,
                    Name = e.Title,
                    Description = e.Description,
                    Address = e.Address,
                    StartDate = e.Start,
                    EndDate = e.End,
                    OpenSubscription = e.Open
                }).ToList();
            C.EmployeeEvent status;
            for (int i = 0; i < Events.Count(); i++)
            {
                status = EventService.GetEmployeeSubscriptionStatus(Events.ElementAt(i).Id, SessionUser.GetUser().Id).FirstOrDefault();
                if (status is null)
                {
                    Events.ElementAt(i).Subscribed = null;
                }
                else
                {
                    Events.ElementAt(i).Subscribed = status.Subscribed;
                }
            }
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

            foreach (C.Department dep in DepartmentService.GetAllActive())
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
                EventService.Create(
                    new C.Event(SessionUser.GetUser().Id, Form.SelectedDepartmentId, Form.Name, Form.Description, Form.Address, Form.StartDate, Form.EndDate.AddHours(23.99999), Form.OpenEvent),
                    SessionUser.GetUser().Id);
                return RedirectToAction("Index");
            }
            List<SelectListItem> DepartmentList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Toute l'entreprise",
                    Value = "-1"
                }
            };

            foreach (C.Department dep in DepartmentService.GetAllActive())
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = dep.Title,
                    Value = dep.Id.ToString()
                });
            }
            Form.DepartmentList = DepartmentList;
            return View(Form);
        }

        public ActionResult Edit(int id)
        {
            C.Event Event = EventService.Get(id);
            List<SelectListItem> DepartmentList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Toute l'entreprise",
                    Value = "-1"
                }
            };

            foreach (C.Department dep in DepartmentService.GetAllActive())
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = dep.Title,
                    Value = dep.Id.ToString()
                });
            }
            EditForm form = new EditForm
            {
                Id = (int)Event.Id,
                Name = Event.Title,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.Start,
                EndDate = Event.End.AddHours(24),
                OpenEvent = Event.Open,
                DepartmentList = DepartmentList,
                SelectedDepartmentId = Event.DepartmentId,
                CreatorId = Event.CreatorId,
                Created = Event.Created
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
                EventService.Edit(new C.Event(Form.Id, Form.CreatorId, Form.SelectedDepartmentId, Form.Name, Form.Description, Form.Address, Form.StartDate, Form.EndDate, Form.Created, null, Form.OpenEvent, false), SessionUser.GetUser().Id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            C.Event Event = EventService.Get(id);
            DeleteForm form = new DeleteForm
            {
                Id = (int)Event.Id,
                CreatorId = Event.CreatorId,
                Name = Event.Title,
                Description = Event.Description,
                DepartmentId = Event.DepartmentId,
                Address = Event.Address,
                StartDate = Event.Start,
                EndDate = Event.End,
                CreationDate = Event.Created
            };
            return View(form);
        }

        [HttpPost]
        public ActionResult Delete(DeleteForm form)
        {
            C.Event e = new C.Event(form.Id, form.CreatorId, null, form.Name, form.Description, form.Address, form.StartDate, form.EndDate, form.CreationDate, null, form.OpenSubscription, false);
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
            C.Event Event = EventService.Get(id);
            DetailsForm form = new DetailsForm
            {
                Id = (int)Event.Id,
                CreatorId = Event.CreatorId,
                Name = Event.Title,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.Start,
                EndDate = Event.End,
                CreationDate = Event.Created
            };
            return View(form);
        }

        public ActionResult SubscribeEmployees(int id)
        {
            IEnumerable<C.EmployeeEvent> EmployeesStatus = EventService.GetSubscriptionStatus(id);
            IEnumerable<C.Employee> EmployeeList = EmployeeService.GetAllActive();

            List<EmployeeSelectorForm> EmployeesForm = new List<EmployeeSelectorForm>();
            foreach (C.Employee e in EmployeeList)
            {
                EmployeesForm.Add(new EmployeeSelectorForm
                {
                    Employee = e,
                    EmployeeId = (int)e.Employee_Id,
                    EventId = id,
                    Selected = EmployeesStatus.Where((employee) => employee.EmployeeId == e.Employee_Id).Count() == 1
                });
            }
            return View(EmployeesForm);
        }

        [HttpPost]
        public ActionResult SubscribeEmployees(IEnumerable<EmployeeSelectorForm> Form)
        {
            foreach (EmployeeSelectorForm item in Form)
            {
                if (item.Selected)
                {
                    EventService.Participate(item.EventId, item.EmployeeId);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult ConfirmSubscription(int id)
        {
            C.Event Event = EventService.Get(id);
            DetailsForm Form = new DetailsForm
            {
                Id = (int)Event.Id,
                CreatorId = Event.CreatorId,
                DepartmentId = Event.DepartmentId,
                Name = Event.Title,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.Start,
                EndDate = Event.End,
                OpenSubscription = Event.Open,
                CreationDate = Event.Created
            };

            return View(Form);
        }

        [HttpPost]
        public ActionResult ConfirmSubscription(DetailsForm Form)
        {

            EventService.Participate(Form.Id, SessionUser.GetUser().Id);
            return RedirectToAction("Index");
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