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
            if (ModelState.IsValid)
            {
                MessageService.Create(new C.Message(form.Title, form.Message, SessionUser.GetUser().Id, form.ReplyTo), form.ToEmployee, form.ToProject, form.ToTask, form.ToTeam);
                return new ContentResult { Content = "success" };
            }
            return new ContentResult {Content = "fail" };
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
        public PartialViewResult AddMessages(ResponseForm form)
        {
            IEnumerable<C.Message> Data = new List<C.Message>();
            if (!(form.ToProject is null))
            {
                if (form.max_id == 0)
                {
                    Data = MessageService.GetProjectMessages((int)form.ToProject);
                }
                else
                {
                    Data = MessageService.GetProjectMessagesWithoutSome((int)form.ToProject, form.max_id);
                }
            }
            else if (!(form.ToTask is null))
            {
                if (form.max_id == 0)
                {
                    Data = MessageService.GetTaskMessages((int)form.ToTask);
                }
                else
                {
                    Data = MessageService.GetTaskMessagesWithoutSome((int)form.ToTask, form.max_id);
                }
            }
            else if (!(form.ToTeam is null))
            {
                if (form.max_id == 0)
                {
                    Data = MessageService.GetTeamMessages((int)form.ToTeam);
                }
                else
                {
                    Data = MessageService.GetTeamMessagesWithoutSome((int)form.ToTeam, form.max_id);
                }
            }
            else if (!(form.ToEmployee is null))
            {
                if (form.max_id == 0)
                {
                    Data = MessageService.GetMyDiscussionWithEmployee(SessionUser.GetUser().Id, (int)form.ToEmployee);
                }
                else
                {
                    Data = MessageService.GetMyDiscussionWithEmployeeWithoutSome(SessionUser.GetUser().Id, (int)form.ToEmployee, form.max_id);
                }
            }
            var result = PartialView(Data.OrderByDescending(message => message.Id).Select(message => new ViewForm
            {
                Id = (int)message.Id,
                Title = message.Title,
                Message = message.Body,
                Parent = message.Parent,
                Author = EmployeeService.Get(message.Author),
                CreationTime = message.Created,
                Children = new List<ViewForm>()
            }));

            return result;
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