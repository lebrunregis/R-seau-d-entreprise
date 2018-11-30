using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class DiscussionForm
    {
        public int? ToEmployee { get; set; }
        public int? ToTask { get; set; }
        public int? ToTeam { get; set; }
        public int? ToProject { get; set; }
        public IEnumerable<ViewForm> Messages { get; set; }
    }
}