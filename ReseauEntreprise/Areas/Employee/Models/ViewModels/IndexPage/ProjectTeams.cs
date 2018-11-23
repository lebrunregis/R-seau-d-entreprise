using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using D = Model.Global.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage
{
    public class ProjectTeams
    {
        [DisplayName("Mes equipes")]
        public List<D.Team> Teams { get; set; }
        [DisplayName("Mes projets")]
        public D.Project Project { get; set; }
    }
}