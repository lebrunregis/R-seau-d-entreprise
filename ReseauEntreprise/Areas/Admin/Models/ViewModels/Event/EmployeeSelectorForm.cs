using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class EmployeeSelectorForm
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        public bool Selected { get; set; }
        [Required]
        [HiddenInput]
        [Key]
        public int EventId { get; set; }
    }
}