using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class ListForm
    {
        [Key]
        [Required]
        [HiddenInput]
        public int? Id { get; set; }
        [Required]
        [HiddenInput]
        public int ProjectId { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Deadline { get; set; }
        [Required]
        public int? SubtaskOf { get; set; }
        [Required]
        public string StatusName { get; set; }
        [Required]
        [HiddenInput]
        public DateTime? StatusDate { get; set; }
        [Required]
        [HiddenInput]
        public int? StatusId { get; set; }
        [Required]
        public int? TeamId { get; set; }
    }
}