using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class DetailsForm
    {
        [Required]
        [Display(Name = "Event Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Creator Id")]
        public int CreatorId { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Department Id")]
        public int? DepartmentId { get; set; }
        [Required]
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
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime CreationDate { get; set; }
        [Required]
        [Display(Name = "Open Subscriptions")]
        public bool OpenSubscription { get; set; }
        public C.Employee Creator { get; set; }
        public C.Department Department { get; set; }
    }
}