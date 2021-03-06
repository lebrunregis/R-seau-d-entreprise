﻿using ReseauEntreprise.CustomDataAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Admin.Models.ViewModels.Project
{
    public class CreateForm
    {
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
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
        [EndDate(nameof(StartDate))]
        public DateTime? EndDate { get; set; }
    }
}