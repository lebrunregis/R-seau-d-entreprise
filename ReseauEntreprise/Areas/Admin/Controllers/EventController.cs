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
            return View( new CreateForm());
        }
        public ActionResult Update(int id)
        {
            EventService.G
            return View();
        }

        public ActionResult CancelEvent(int id)
        {

            return View();
        }
        public ActionResult Details(int id)
        {

            return View();
        }

        public ActionResult SubscribeEmployees(int id)
        {

            return View();
        }

        public ActionResult ConfirmSubscribtion(int id)
        {

            return View();
        }

        public ActionResult Attendance(int id)
        {

            return View();
        }

        public ActionResult CancelSubscription(int id)
        {

            return View();
        }
    }
}