using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Admin.Models.ViewModels.Team
{
    public class CreateForm
    {
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Team Leader")]
        public int SelectedTeamLeaderId { get; set; }
        public IEnumerable<SelectListItem> TeamLeaderCandidateList { get; set; }
        [Required]
        [Display(Name = "Project")]
        public int SelectedProjectId { get; set; }
        public IEnumerable<SelectListItem> ProjectCandidateList { get; set; }
    }
}