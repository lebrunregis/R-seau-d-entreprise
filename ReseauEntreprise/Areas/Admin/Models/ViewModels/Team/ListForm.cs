using C = Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Team
{
    public class ListForm
    {
        [Key]
        public int TeamId { get; set; }
        public String Name { get; set; }
        public DateTime CreationDate { get; set; }
        public C.Employee TeamLeader { get; set; }
        public C.Employee Creator { get; set; }
        public C.Project Project { get; set; }
        public DateTime? EndDate { get; set; }


        public ListForm()
        {

        }

        public ListForm(C.Team Team, C.Employee TeamLeader, C.Employee Creator, C.Project Project)
        {
            TeamId = (int) Team.Id;
            Name = Team.Name;
            this.TeamLeader = TeamLeader;
            this.Creator = Creator;
            this.Project = Project;
            CreationDate = Team.Created;
            EndDate = Team.Disbanded;
        }
    }
}