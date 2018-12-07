using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class DiscussionScriptForm
    {
        public int? ToEmployee { get; set; }
        public int? ToProject { get; set; }
        public int? ToTask { get; set; }
        public int? ToTeam { get; set; }
    }
}