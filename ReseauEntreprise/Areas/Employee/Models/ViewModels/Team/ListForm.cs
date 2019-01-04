﻿using D = Model.Client.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Team
{
    public class ListForm
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public D.Employee TeamLeader { get; set; }
        public D.Employee ProjectManager { get; set; }
        [Display(Name = "Projet")]
        public D.Project Project { get; set; }
        [Display(Name = "Deadline du projet")]
        public DateTime? ProjectDeadLine { get; set; }
        public bool AmIPartOfTeam { get; set; }
        public bool AmITeamLeader { get; set; }
        public bool AmIProjectManager { get; set; }
        
    }
}