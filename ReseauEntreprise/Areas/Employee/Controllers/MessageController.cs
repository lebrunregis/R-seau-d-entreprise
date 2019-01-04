﻿using C = Model.Client.Data;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Message;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Hubs;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class MessageController : Controller
    {

        [HttpPost]
        public ContentResult Send(SendForm form)
        {
            if (ModelState.IsValid)
            {
                int MyId = SessionUser.GetUser().Id;
                int? newMessageId = MessageService.Create(new C.Message(form.Title, form.Message, MyId, form.ReplyTo), form.ToEmployee, form.ToProject, form.ToTask, form.ToTeam);
                if (newMessageId != null)
                {
                    if (form.ToEmployee != null)
                    {
                        EmployeeHub.Send((int)form.ToEmployee);
                        MailboxHub.Send((int)form.ToEmployee);
                    }
                    else
                    {
                        if (form.ReplyTo != null)
                        {
                            int ParentAuthor = MessageService.Get((int)form.ReplyTo).Author;
                            MailboxHub.Send(ParentAuthor);
                        }
                        if (form.ToProject != null)
                        {
                            ProjectHub.Send((int)form.ToProject);
                        }
                        else if (form.ToTask != null)
                        {
                            TaskHub.Send((int)form.ToTask);
                        }
                        else if (form.ToTeam != null)
                        {
                            TeamHub.Send((int)form.ToTeam);
                        }
                    }
                    return new ContentResult { Content = "success" };
                }
            }
            return new ContentResult {Content = "fail" };
        }

        public ActionResult _Discussion(int? ProjectId = null, int? TaskId = null, int? TeamId = null, int? EmployeeId = null)
        {
            IEnumerable<C.Message> messages = new List<C.Message>();
            if (!(ProjectId is null))
            {
                messages = MessageService.GetProjectMessages((int)ProjectId);
            }
            else if (!(TaskId is null))
            {
                messages = MessageService.GetTaskMessages((int)TaskId);
            }
            else if (!(TeamId is null))
            {
                messages = MessageService.GetTeamMessages((int)TeamId);
            }
            else if (!(EmployeeId is null))
            {
                messages = MessageService.GetMyDiscussionWithEmployee(SessionUser.GetUser().Id, (int)EmployeeId);
            }
            DiscussionForm form = new DiscussionForm
            {
                ToEmployee = EmployeeId,
                ToProject = ProjectId,
                ToTeam = TeamId,
                ToTask = TaskId,
                Messages = FillAndAddChildren(messages, null)
            };
            return PartialView(form);
        }

        [HttpPost]
        public PartialViewResult _Messages(ResponseForm form)
        {
            IEnumerable<C.Message> Data = new List<C.Message>();
            if (!(form.ToProject is null))
            {
                if (form.Max_id == 0)
                {
                    Data = MessageService.GetProjectMessages((int)form.ToProject);
                }
                else
                {
                    Data = MessageService.GetProjectMessagesWithoutSome((int)form.ToProject, form.Max_id);
                }
            }
            else if (!(form.ToTask is null))
            {
                if (form.Max_id == 0)
                {
                    Data = MessageService.GetTaskMessages((int)form.ToTask);
                }
                else
                {
                    Data = MessageService.GetTaskMessagesWithoutSome((int)form.ToTask, form.Max_id);
                }
            }
            else if (!(form.ToTeam is null))
            {
                if (form.Max_id == 0)
                {
                    Data = MessageService.GetTeamMessages((int)form.ToTeam);
                }
                else
                {
                    Data = MessageService.GetTeamMessagesWithoutSome((int)form.ToTeam, form.Max_id);
                }
            }
            else if (!(form.ToEmployee is null))
            {
                if (form.Max_id == 0)
                {
                    Data = MessageService.GetMyDiscussionWithEmployee(SessionUser.GetUser().Id, (int)form.ToEmployee);
                }
                else
                {
                    Data = MessageService.GetMyDiscussionWithEmployeeWithoutSome(SessionUser.GetUser().Id, (int)form.ToEmployee, form.Max_id);
                }
            }
            var result = PartialView(Data.OrderByDescending(message => message.Id).Select(message => new ViewForm(message)));

            return result;
        }

        private IEnumerable<ViewForm> FillAndAddChildren(IEnumerable<C.Message> messages, int? ParentId)
        {
            return messages.Where(message => message.Parent == ParentId).OrderBy(message => message.Id).Select(message =>
            new ViewForm(message, FillAndAddChildren(messages, message.Id)));
        }

        public ActionResult Mailbox()
        {
            int EmployeeId = SessionUser.GetUser().Id;
            IEnumerable<MailboxForm> messages = MessageService.GetResponsesToEmployee(EmployeeId).Select(message => new MailboxForm(message, EmployeeId));
            return View(new MailboxGeneralForm
            {
                Messages = messages,
                MyId = EmployeeId
            });
        }

        [HttpPost]
        public PartialViewResult _Mailbox(MaxIdForm MaxId)
        {
            int EmployeeId = SessionUser.GetUser().Id;
            IEnumerable<MailboxForm> form = MessageService.GetResponsesToEmployeeWithoutSome(EmployeeId, MaxId.Max_id).Select(message => new MailboxForm(message, EmployeeId));
            return PartialView(form);
        }
    }
}