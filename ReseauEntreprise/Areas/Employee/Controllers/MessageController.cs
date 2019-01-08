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
            return _Discussion(ProjectId, null, null, null);
        }
        [TeamMemberRequired]
        public ActionResult _DiscussionTask(int TaskId)
        {
            return _Discussion(null, TaskId, null, null);
        }
        [TeamMemberRequired]
        public ActionResult _DiscussionTeam(int TeamId)
        {
            return _Discussion(null, null, TeamId, null);
        }
        public ActionResult _DiscussionEmployee(int EmployeeId)
        {
            return _Discussion(null, null, null, EmployeeId);
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
        public PartialViewResult _MessagesProject(ResponseForm form, int? ProjectId)
        {
            return _Messages(form, ProjectId, null, null, null);
        }
        [TeamMemberRequired]
        [HttpPost]
        public PartialViewResult _MessagesTask(ResponseForm form, int? TaskId)
        {
            return _Messages(form, null, TaskId, null, null);
        }
        [TeamMemberRequired]
        [HttpPost]
        public PartialViewResult _MessagesTeam(ResponseForm form, int? TeamId)
        {
            return _Messages(form, null, null, TeamId, null);
        }
        [HttpPost]
        public PartialViewResult _MessagesEmployee(ResponseForm form, int? EmployeeId)
        {
            return _Messages(form, null, null, null, EmployeeId);
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

        private ActionResult _Discussion(int? ProjectId, int? TaskId, int? TeamId, int? EmployeeId)
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
            return PartialView("_Discussion", form);
        }

        [HttpPost]
        private PartialViewResult _Messages(ResponseForm form, int? ProjectId, int? TaskId, int? TeamId, int? EmployeeId)
        {
            IEnumerable<C.Message> Data = new List<C.Message>();
            if (!(ProjectId is null))
            {
                if (form.Max_id == -1)
                {
                    Data = MessageService.GetProjectMessages((int)ProjectId);
                }
                else
                {
                    Data = MessageService.GetProjectMessagesWithoutSome((int)ProjectId, form.Max_id);
                }
            }
            else if (!(TaskId is null))
            {
                if (form.Max_id == -1)
                {
                    Data = MessageService.GetTaskMessages((int)TaskId);
                }
                else
                {
                    Data = MessageService.GetTaskMessagesWithoutSome((int)TaskId, form.Max_id);
                }
            }
            else if (!(TeamId is null))
            {
                if (form.Max_id == -1)
                {
                    Data = MessageService.GetTeamMessages((int)TeamId);
                }
                else
                {
                    Data = MessageService.GetTeamMessagesWithoutSome((int)TeamId, form.Max_id);
                }
            }
            else if (!(EmployeeId is null))
            {
                if (form.Max_id == -1)
                {
                    Data = MessageService.GetMyDiscussionWithEmployee(SessionUser.GetUser().Id, (int)EmployeeId);
                }
                else
                {
                    Data = MessageService.GetMyDiscussionWithEmployeeWithoutSome(SessionUser.GetUser().Id, (int)EmployeeId, form.Max_id);
                }
            }
            var result = PartialView("_Messages", Data.OrderByDescending(message => message.Id).Select(message => new ViewForm(message)));

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