﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using C = Model.Client.Data;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;
using TaskForm = ReseauEntreprise.Areas.Employee.Models.ViewModels.Task.ListForm;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Project
{
    public class DetailsForm
    {
        [Required]
        [Editable(false)]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Project Manager")]
        public C.Employee Manager { get; set; }
        [Required]
        [Display(Name = "Creator")]
        public C.Employee Creator { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime? EndDate { get; set; }
        public IEnumerable<C.Team> Teams { get; set; }
        public IEnumerable<TaskForm> Tasks { get; set; }
        public IEnumerable<Doc.ListForm> Documents { get; set; }
        public Message.DiscussionScriptForm DiscScriptForm { get; set; }
        [Display(Name = "Project Manager")]
        public bool IsProjectManager { get; set; }
    }
}