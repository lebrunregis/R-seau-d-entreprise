using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using D = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage
{
    public class IndexForm
    {
        public IEnumerable<ProjectTeamsForm> ProjectTeamList { get; set; }
        [DisplayName("My Departments")]
        public IEnumerable<D.Department> MyDepartments { get; set; }
        [DisplayName("Projects where I am Project Manager")]
        public IEnumerable<D.Project> ProjectManagerProjects { get; set; }
        [DisplayName("Departments where I am Head of Department")]
        public IEnumerable<D.Department> HeadOfDepartmentDepartments { get; set; }
        [DisplayName("Teams where I am Team Leader")]
        public IEnumerable<D.Team> TeamLeaderTeams { get; set; }
    }
}