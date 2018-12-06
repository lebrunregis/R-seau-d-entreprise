using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C = Model.Client.Data;
using Model.Client.Service;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class MailboxForm
    {
        public ViewForm Message { get; set; }
        public C.Project project { get; set; }
        public C.Task task { get; set; }
        public C.Team team { get; set; }
        public C.Employee employee { get; set; }
        public SendForm form { get; set; }
        public bool isReplied { get; set; } 

        public MailboxForm()
        {

        }
        public MailboxForm(C.Message m, int MyId)
        {
            Message = new ViewForm(m);
            project = MessageService.GetProjectForMessage((int)m.Id).FirstOrDefault();
            team = MessageService.GetTeamForMessage((int)m.Id).FirstOrDefault();
            //task = MessageService.GetTaskForMessage((int)m.Id);
            employee = Message.Author;
            form = new SendForm {
                ToEmployee = (task == null && project== null && team==null) ? employee.Employee_Id : null,
                ToTask = (task != null) ? task.Id : null,
                ToTeam = (team != null) ? team.Id : null,
                ToProject = (project != null) ? project.Id : null,
                ReplyTo = Message.Id
            };
            isReplied = MessageService.IsMessageRepliedByEmployee((int)m.Id, MyId);
        }
    }
}