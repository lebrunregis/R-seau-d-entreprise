using System.Linq;
using C = Model.Client.Data;
using Model.Client.Service;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class MailboxForm
    {
        public ViewForm Message { get; set; }
        public C.Project Project { get; set; }
        public C.Task Task { get; set; }
        public C.Team Team { get; set; }
        public C.Employee Employee { get; set; }
        public SendForm Form { get; set; }
        public bool IsReplied { get; set; } 

        public MailboxForm()
        {

        }
        public MailboxForm(C.Message m, int MyId)
        {
            Message = new ViewForm(m);
            Project = MessageService.GetProjectForMessage((int)m.Id).FirstOrDefault();
            Team = MessageService.GetTeamForMessage((int)m.Id).FirstOrDefault();
            Task = MessageService.GetTaskForMessage((int)m.Id).FirstOrDefault();
            Employee = Message.Author;
            Form = new SendForm {
                ToEmployee = (Task == null && Project== null && Team==null) ? Employee.Employee_Id : null,
                ToTask = Task?.Id,
                ToTeam = Team?.Id,
                ToProject = Project?.Id,
                ReplyTo = Message.Id
            };
            IsReplied = MessageService.IsMessageRepliedByEmployee((int)m.Id, MyId);
        }
    }
}