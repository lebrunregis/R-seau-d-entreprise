using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Team
{
    public class CreateForm
    {
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        //[Required]
        //[Display(Name = "Team Leader")]
        public IEnumerable<SelectListItem> TeamLeaderCandidateList { get; set; }
        public int SelectedTeamLeaderId { get; set; }
        [Required]
        [Display(Name = "Project")]
        public int SelectedProjectId { get; set; }
        public IEnumerable<SelectListItem> ProjectCandidateList { get; set; }
    }
}