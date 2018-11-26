using D = Model.Global.Data;
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