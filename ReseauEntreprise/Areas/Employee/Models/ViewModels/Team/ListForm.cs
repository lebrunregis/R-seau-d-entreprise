using D = Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Team
{
    public class ListForm
    {
        [Key]
        [Display(Name = "Team")]
        public int TeamId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Created")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Team Leader")]
        public D.Employee TeamLeader { get; set; }
        [Display(Name = "Project Manager")]
        public D.Employee ProjectManager { get; set; }
        [Display(Name = "Projet")]
        public D.Project Project { get; set; }
        [Display(Name = "Deadline du projet")]
        public DateTime? ProjectDeadLine { get; set; }
        [Display(Name = "Part of team")]
        public bool AmIPartOfTeam { get; set; }
        [Display(Name = "Team leader")]
        public bool AmITeamLeader { get; set; }
        [Display(Name = "Project manager")]
        public bool AmIProjectManager { get; set; }
        
    }
}