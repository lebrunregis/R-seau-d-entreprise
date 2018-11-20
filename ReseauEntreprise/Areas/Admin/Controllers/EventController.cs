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
            return View(new CreateForm());
        }

        public ActionResult Update(int id)
        {
            G.Event Event = EventService.Get(id);
            EditForm form = new EditForm
            {
                Id = Event.Id,
                CreatorId = Event.CreatorId,
                Name = Event.Name,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.StartDate,
                EndDate = Event.EndDate,
                CreationDate = Event.CreationDate,
                OpenEvent = Event.Open
            };
            return View(form);
        }

        public ActionResult CancelEvent(int id)
        {
            G.Event Event = EventService.Get(id);
            DeleteForm form = new DeleteForm
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
            return View();
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
            EmployeeService.GetAllActive();
            EventService.Get(id);
            return View();
        }

        public ActionResult ConfirmSubscription(int id)
        {
            EventService.Get(id);
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