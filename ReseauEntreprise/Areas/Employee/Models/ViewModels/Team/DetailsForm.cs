using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Team
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
        [Display(Name = "Team Leader")]
        public C.Employee TeamLeader { get; set; }
        [Required]
        [Display(Name = "Creator")]
        public C.Employee Creator { get; set; }
        [Required]
        public C.Project Project { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public IEnumerable<C.Employee> Members { get; set; }
        public bool IsTeamLeader { get; set; }
        public bool IsProjectManagerOrAdmin {get ; set; }
        public IEnumerable<C.Task> Tasks { get ; set; }
        public Message.DiscussionScriptForm DiscScriptForm { get; set; }
    }
}