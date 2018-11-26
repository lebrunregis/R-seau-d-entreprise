using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using D = Model.Global.Data;
using System.ComponentModel;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class EmployeeSelectorForm
    {
        [DisplayName("Employé")]
        public D.Employee Employee { get; set; }
        [Required]
        [HiddenInput]
        public int EmployeeId { get; set; }
        [Required]
        public bool Selected { get; set; }
        [Required]
        [HiddenInput]
        public int EventId { get; set; }
    }
}