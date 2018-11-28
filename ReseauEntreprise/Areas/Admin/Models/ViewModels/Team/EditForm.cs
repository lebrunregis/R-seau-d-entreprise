using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D = Model.Global.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Team
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
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Team Leader")]
        public int SelectedTeamLeaderId { get; set; }
        public IEnumerable<SelectListItem> TeamLeaderCandidateList { get; set; }
        [HiddenInput]
        public DateTime Created { get; set; }
    }
}