using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using C = Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Event;
using Réseau_d_entreprise.Session.Attributes;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;

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
                    Name = e.Title,
                    Description = e.Description,
                    Address = e.Address,
                    StartDate = e.Start,
                    EndDate = e.End,
                    OpenSubscription = e.Open,
                    Subscribed = (e.Subscribed != null)
                });

            return View(Events);
        }

        public ActionResult Details(int id)
        {
            C.Event Event = EventService.Get(id);
            IEnumerable<C.EmployeeEvent> SubscribedEmployees = EventService.GetSubscriptionStatus(id);
            bool subscribed = false;
            foreach (C.EmployeeEvent Subscription in SubscribedEmployees)
            {
                if (Subscription.EmployeeId == SessionUser.GetUser().Id && !(bool)Subscription.Cancelled)
                {
                    subscribed = true;
                }
            }
            DetailsForm form = new DetailsForm
            {
                Id = (int)Event.Id,
                CreatorId = Event.CreatorId,
                Name = Event.Title,
                Description = Event.Description,
                Address = Event.Address,
                StartDate = Event.Start,
                EndDate = Event.End,
                CreationDate = Event.Created,
                OpenSubscription = Event.Open,
                Subscribed = subscribed,
                Documents = DocumentService.GetForEvent((int)Event.Id).Select(d => new Doc.ListForm { Name = d.Filename, Id = (int)d.Id })
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

        public ActionResult CancelSubscription(int id)
        {
            EventService.Get(id);
            return View();
        }
    }
}