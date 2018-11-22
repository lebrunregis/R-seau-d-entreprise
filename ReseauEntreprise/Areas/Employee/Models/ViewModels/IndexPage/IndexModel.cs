using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using D = Model.Global.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage
{
    public class IndexModel
    {
        public IEnumerable<ProjectTeams> ProjectTeamTable { get; set; }
        [DisplayName("Mes departements")]
        public IEnumerable<D.Department> MyDepartments { get; set; }
        [DisplayName("Mes departements")]
        public IEnumerable<D.Project> ProjectManagerProjects { get; set; }
    }
}