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
        public ViewForm message { get; set; }
        public C.Project project { get; set; }
        public C.Task task { get; set; }
        public C.Team team { get; set; }
        public C.Employee employee { get; set; }

        public MailboxForm()
        {

        }
        public MailboxForm(C.Message m)
        {
            message = new ViewForm(m);
            project = MessageService.GetProjectForMessage((int)m.Id);
            team = MessageService.GetTeamForMessage((int)m.Id);
            //task = MessageService.GetTaskForMessage((int)m.Id);
            employee = message.Author;
        }
    }
}