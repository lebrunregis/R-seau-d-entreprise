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
        public IEnumerable<ProjectTeams> ProjectTeamList { get; set; }
        [DisplayName("Mes départements")]
        public IEnumerable<D.Department> MyDepartments { get; set; }
        [DisplayName("Projets que je mène")]
        public IEnumerable<D.Project> ProjectManagerProjects { get; set; }
        [DisplayName("Departements que je mène")]
        public IEnumerable<D.Department> HeadOfDepartmentDepartments { get; set; }
        [DisplayName("Equipes que je mène")]
        public IEnumerable<D.Team> TeamLeaderTeams { get; set; }
    }
}