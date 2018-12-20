using System.Collections.Generic;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class MailboxGeneralForm
    {
        public int MyId { get; set; }
        public IEnumerable<MailboxForm> Messages { get; set; }
    }
}