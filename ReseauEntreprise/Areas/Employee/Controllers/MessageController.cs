using ReseauEntreprise.Areas.Employee.Models.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Compose()
        {
            SendForm form = new SendForm();
            return PartialView(form);
        }
        [HttpPost]
        public ActionResult Send(SendForm form)
        {
            return View();
        }
        public ActionResult Visualise(int id)
        {

        }
    }
}