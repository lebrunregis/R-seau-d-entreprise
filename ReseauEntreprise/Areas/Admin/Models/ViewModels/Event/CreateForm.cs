using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class CreateForm
    {
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Display(Name = "Address")]
        public String Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int? SelectedDepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        [Required]
        [Display(Name = "Open Subscriptions")]
        public bool OpenEvent { get; set; }
    }
}