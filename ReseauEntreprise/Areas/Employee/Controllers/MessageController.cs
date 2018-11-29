using C=Model.Client.Data;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class MessageController : Controller
    {
        public ActionResult Send()
        {
            SendForm form = new SendForm();
            return PartialView(form);
        }
        [HttpPost]
        public ActionResult Send(SendForm form)
        {
            return View();
        }
        public ActionResult ViewProjectDiscussion(int Project_Id)
        {
            IEnumerable<C.Message> messages = MessageService.GetProjectMessages(Project_Id);
            IEnumerable<ViewForm> form = FillAndAddChildren(messages, null);
            return View(form);
        }

        private IEnumerable<ViewForm> FillAndAddChildren(IEnumerable<C.Message> messages, int? ParentId)
        {
            return messages.Where(message => message.Parent == ParentId).Select(message =>
            new ViewForm
            {
                Id = (int)message.Id,
                Title = message.Title,
                Message = message.Body,
                Parent = ParentId,
                Author = EmployeeService.Get(message.Author),
                CreationTime = message.Created,
                Children = FillAndAddChildren(messages, message.Id)
            });
        }

        public ActionResult MessagePartial_SendTemplate()
        {
            return View();
        }
    }
}