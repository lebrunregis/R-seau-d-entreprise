using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ReseauEntreprise.CustomDataAttributes;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class EditForm
    {
        [Required]
        [Key]
        [Display(Name = "Event Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Display(Name = "Address")]
        public String Address { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int? SelectedDepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [EndDate(nameof(StartDate))]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Open Subscription")]
        public bool OpenEvent { get; set; }
        [HiddenInput]
        [Required]
        public int CreatorId { get; set; }
        [HiddenInput]
        [Required]
        public DateTime Created { get; set; }
    }
}