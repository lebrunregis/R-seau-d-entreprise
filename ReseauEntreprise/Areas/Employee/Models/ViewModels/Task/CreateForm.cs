﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class CreateForm
    {
        [Required]
        [HiddenInput]
        [Editable(false)]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
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
        public IEnumerable<SelectListItem> TeamList { get; set; }
        [HiddenInput]
        [Display(Name = "Team")]
        public int? SelectedTeamId { get; set; }
        public C.Project Project { get; set; }
        public C.Task Parent { get; set; }
    }
}