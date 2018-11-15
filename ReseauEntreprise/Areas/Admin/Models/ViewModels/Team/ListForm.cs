using D = Model.Global.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Admin.Models.ViewModels.Team
{
    public class ListForm
    {
        [Required]
        [HiddenInput]
        [Key]
        public int TeamId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [HiddenInput]
        [Required]
        public D.Employee TeamLeader { get; set; }
        [HiddenInput]
        [Required]
        public D.Employee Creator { get; set; }
        [HiddenInput]
        [Required]
        public D.Project Project { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate;
        [DataType(DataType.Date)]
        public DateTime? EndDate;


        public ListForm()
        {

        }

        public ListForm(D.Team Team, D.Employee TeamLeader, D.Employee Creator, D.Project Project)
        {
            TeamId = Team.Id;
            Name = Team.Name;
            this.TeamLeader = TeamLeader;
            this.Creator = Creator;
            this.Project = Project;
            this.CreationDate = Team.Created;
            this.EndDate = Team.Disbanded;
        }
    }
}