using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class DeleteForm
    {
        [Key]
        [Display(Name = "Event Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Creator Id")]
        public int CreatorId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Display(Name = "Address")]
        public String Address { get; set; }
        [Required]
        [Display(Name = "Department Id")]
        public int? DepartmentId { get; set; }
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
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [Required]
        [Display(Name = "Open Subscriptions")]
        public bool OpenSubscription { get; set; }
    }
}