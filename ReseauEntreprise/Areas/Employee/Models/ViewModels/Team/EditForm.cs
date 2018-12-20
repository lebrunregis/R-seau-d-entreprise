using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Team
{
    public class EditForm
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [HiddenInput]
        [Required]
        public int CreatorId { get; set; }
        [Required]
        [HiddenInput]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Team Leader")]
        public int SelectedTeamLeaderId { get; set; }
        public IEnumerable<SelectListItem> TeamLeaderCandidateList { get; set; }
    }
}