using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class MailboxGeneralForm
    {
        public int MyId { get; set; }
        public IEnumerable<MailboxForm> Messages { get; set; }
    }
}