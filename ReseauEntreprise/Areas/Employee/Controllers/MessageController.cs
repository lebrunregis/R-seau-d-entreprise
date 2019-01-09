using C = Model.Client.Data;
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
        public ActionResult _DiscussionProject(int ProjectId)
        {
            DiscussionForm form = new DiscussionForm { ToProject = ProjectId };
            return _Discussion(MessageService.GetProjectMessages(ProjectId), form);
        }
        [TeamMemberRequired]
        public ActionResult _DiscussionTask(int TaskId)
        {
            DiscussionForm form = new DiscussionForm { ToTask = TaskId };
            return _Discussion(MessageService.GetTaskMessages(TaskId), form);
        }
        [TeamMemberRequired]
        public ActionResult _DiscussionTeam(int TeamId)
        {
            DiscussionForm form = new DiscussionForm { ToTeam = TeamId };
            return _Discussion(MessageService.GetTeamMessages(TeamId), form);
        }
        public ActionResult _DiscussionEmployee(int EmployeeId)
        {
            DiscussionForm form = new DiscussionForm { ToEmployee = EmployeeId };
            return _Discussion(MessageService.GetMyDiscussionWithEmployee(SessionUser.GetUser().Id, EmployeeId), form);
        }




        [HttpPost]
        public ContentResult SendProject(SendForm form, int ProjectId)
        {
            return Send(form, ProjectId, null, null, null);
        }
        [TeamMemberRequired]
        [HttpPost]
        public ContentResult SendTask(SendForm form, int TaskId)
        {
            return Send(form, null, TaskId, null, null);
        }
        [TeamMemberRequired]
        [HttpPost]
        public ContentResult SendTeam(SendForm form, int TeamId)
        {
            return Send(form, null, null, TeamId, null);
        }
        [HttpPost]
        public ContentResult SendEmployee(SendForm form, int EmployeeId)
        {
            return Send(form, null, null, null, EmployeeId);
        }





        [HttpPost]
        public PartialViewResult _MessagesProject(MaxIdForm form, int ProjectId)
        {
            if (form.Max_id == -1)
            {
                return _Messages(MessageService.GetProjectMessages(ProjectId));
            }
            else
            {
                return _Messages(MessageService.GetProjectMessagesWithoutSome(ProjectId, form.Max_id));
            }
        }
        [TeamMemberRequired]
        [HttpPost]
        public PartialViewResult _MessagesTask(MaxIdForm form, int TaskId)
        {
            if (form.Max_id == -1)
            {
                return _Messages(MessageService.GetTaskMessages(TaskId));
            }
            else
            {
                return _Messages(MessageService.GetTaskMessagesWithoutSome(TaskId, form.Max_id));
            }
        }
        [TeamMemberRequired]
        [HttpPost]
        public PartialViewResult _MessagesTeam(MaxIdForm form, int TeamId)
        {
            if (form.Max_id == -1)
            {
                return _Messages(MessageService.GetTeamMessages(TeamId));
            }
            else
            {
                return _Messages(MessageService.GetTeamMessagesWithoutSome(TeamId, form.Max_id));
            }
        }
        [HttpPost]
        public PartialViewResult _MessagesEmployee(MaxIdForm form, int EmployeeId)
        {
            if (form.Max_id == -1)
            {
                return _Messages(MessageService.GetMyDiscussionWithEmployee(SessionUser.GetUser().Id, EmployeeId));
            }
            else
            {
                return _Messages(MessageService.GetMyDiscussionWithEmployeeWithoutSome(SessionUser.GetUser().Id, EmployeeId, form.Max_id));
            }
        }



        private ContentResult Send(SendForm form, int? ProjectId, int? TaskId, int? TeamId, int? EmployeeId)
        {
            if (ModelState.IsValid)
            {
                int MyId = SessionUser.GetUser().Id;
                int? newMessageId = MessageService.Create(new C.Message(form.Title, form.Message, MyId, form.ReplyTo), EmployeeId, ProjectId, TaskId, TeamId);
                if (newMessageId != null)
                {
                    if (EmployeeId != null)
                    {
                        EmployeeHub.Send((int)EmployeeId);
                        MailboxHub.Send((int)EmployeeId);
                    }
                    else
                    {
                        if (form.ReplyTo != null)
                        {
                            int ParentAuthor = MessageService.Get((int)form.ReplyTo).Author;
                            MailboxHub.Send(ParentAuthor);
                        }

                        if (ProjectId != null)
                        {
                            ProjectHub.Send((int)ProjectId);
                        }
                        else if (TaskId != null)
                        {
                            TaskHub.Send((int)TaskId);
                        }
                        else if (TeamId != null)
                        {
                            TeamHub.Send((int)TeamId);
                        }
                    }
                    return new ContentResult { Content = "success" };
                }
            }
            return new ContentResult {Content = "fail" };
        }


        private ActionResult _Discussion(IEnumerable<C.Message> messages, DiscussionForm form)
        {
            form.Messages = FillAndAddChildren(messages, null);
            return PartialView("_Discussion", form);
        }


        [HttpPost]
        private PartialViewResult _Messages(IEnumerable<C.Message> Data)
        {
            PartialViewResult result = PartialView("_Messages", Data.OrderByDescending(message => message.Id).Select(message => new ViewForm(message)));
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