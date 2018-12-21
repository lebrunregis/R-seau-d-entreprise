using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class ResponseForm
    {
        public int Max_id { get; set; }
        public int? ToEmployee { get; set; }
        public int? ToTask { get; set; }
        public int? ToTeam { get; set; }
        public int? ToProject { get; set; }
    }
}