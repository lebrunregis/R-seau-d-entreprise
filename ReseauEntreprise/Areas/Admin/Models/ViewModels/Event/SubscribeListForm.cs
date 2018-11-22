using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class SubscribeListForm
    {
        [Required]
        public DetailsForm Event { get; set; }
        [Required]
        public IEnumerable<EmployeeSelectorForm> List {get;set;}
    }
}