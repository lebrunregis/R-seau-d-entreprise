using ReseauEntreprise.CustomDataAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Project
{
    public class EditForm
    {
        [Required]
        [HiddenInput]
        [Display(Name = "Project Id")]
        public int Id { get; set; }
        [HiddenInput]
        [Required]
        [Display(Name = "Creator Id")]
        public int CreatorId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Project Name")]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [HiddenInput]
        [Required]
        [Display(Name = "Project Manager Id")]
        public int ProjectManagerId { get; set; }
        [Required]
        [Display(Name = "Project Manager")]
        public int SelectedProjectManagerId { get; set; }
        public IEnumerable<SelectListItem> ProjectManagerCandidateList { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [EndDate(nameof(StartDate))]
        public DateTime? EndDate { get; set; }
    }
}