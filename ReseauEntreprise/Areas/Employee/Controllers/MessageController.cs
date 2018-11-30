using C=Model.Client.Data;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using Réseau_d_entreprise.Session;

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
        public ContentResult Send(SendForm form)
        {
            MessageService.Create(new C.Message(form.Title, form.Message, SessionUser.GetUser().Id, form.ReplyTo), form.ToEmployee, form.ToProject, form.ToTask, form.ToTeam);
            return new ContentResult {Content = "success" };
        }
        public ActionResult ViewProjectDiscussion(int id)
        {
            int Project_Id = id;
            IEnumerable<C.Message> messages = MessageService.GetProjectMessages(Project_Id);
            DiscussionForm form = new DiscussionForm
            {
                ToProject = Project_Id,
                Messages = FillAndAddChildren(messages, null)
            };
            return View(form);
        }
        [HttpPost]
        public ContentResult ViewProjectDiscussion(ResponseForm form)
        {
            string s = string.Join(",", form.ids);
            return new ContentResult { Content = "success" };
        }

        private IEnumerable<ViewForm> FillAndAddChildren(IEnumerable<C.Message> messages, int? ParentId)
        {
            return messages.Where(message => message.Parent == ParentId).OrderBy(message => message.Id).Select(message =>
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
    }
}