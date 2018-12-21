using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class EditForm
    {
        [Key]
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [HiddenInput]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        [Required]
        [HiddenInput]
        [Display(Name = "Creator")]
        public int CreatorId { get; set; }
        [HiddenInput]
        [Display(Name = "Team")]
        public int TeamId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Deadline")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Deadline { get; set; }
        [HiddenInput]
        [Display(Name = "Subtask of")]
        public int? SubtaskOf { get; set; }
        [HiddenInput]
        [DataType(DataType.Date)]
        public List<SelectListItem> StatusList { get; set; }
        [Required]
        [HiddenInput]
        [Display(Name = "Status")]
        public int SelectedStatusId { get; set; }
    }
}