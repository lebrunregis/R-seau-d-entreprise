using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Event;
using Réseau_d_entreprise.Session.Attributes;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class EventController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<ListForm> Events = EventService.GetAllActiveForUser(SessionUser.GetUser().Id)
                .Select(e => new ListForm()
                {
                    Id = (int) e.Id,
                    DepartmentId = e.DepartmentId,
                    Name = e.Name,
                    Description = e.Description,
                    Address = e.Address,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    OpenSubscription = e.Open,
                    Subscribed = e.Subscribed
                });

            return View(Events);
        }

        public ActionResult Details(int id)
        {
            C.Event Event = EventService.Get(id);
            DetailsForm form = new DetailsForm
            {
                Id = (int)Event.Id,
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


        public ActionResult ConfirmSubscription(int id)
        {
            C.Event Event = EventService.Get(id);
            DetailsForm Form = new DetailsForm
            {
                Id = (int)Event.Id,
                CreatorId = Event.CreatorId,
                DepartmentId = Event.DepartmentId,
                Name = Event.Name,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.StartDate,
                EndDate = Event.EndDate,
                OpenSubscription = Event.Open,
                CreationDate = Event.CreationDate
            };

            return View(Form);
        }

        [HttpPost]
        public ActionResult ConfirmSubscription(DetailsForm Form)
        {

            EventService.Participate(Form.Id, SessionUser.GetUser().Id);
            return RedirectToAction("Index");
        }

        public ActionResult CancelSubscription(int id)
        {
            EventService.Get(id);
            return View();
        }
    }
}