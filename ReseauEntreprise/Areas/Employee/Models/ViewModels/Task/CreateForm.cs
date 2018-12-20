using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class CreateForm
    {
        [Required]
        [HiddenInput]
        [Editable(false)]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Deadline { get; set; }
        [HiddenInput]
        public int? SubtaskOf { get; set; }
        public IEnumerable<SelectListItem> TeamList { get; set; }
        [Required]
        [HiddenInput]
        public int SelectedTeamId { get; set; }
    }
}