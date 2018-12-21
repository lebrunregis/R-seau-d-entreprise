using System.Collections.Generic;
using System.ComponentModel;
using D = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage
{
    public class IndexForm
    {
        public IEnumerable<ProjectTeamsForm> ProjectTeamList { get; set; }
        [DisplayName("My Departments")]
        public IEnumerable<D.Department> MyDepartments { get; set; }
        [DisplayName("Project Manager of")]
        public IEnumerable<D.Project> ProjectManagerProjects { get; set; }
        [DisplayName("Head of Department of")]
        public IEnumerable<D.Department> HeadOfDepartmentDepartments { get; set; }
        [DisplayName("Team Leader of")]
        public IEnumerable<D.Team> TeamLeaderTeams { get; set; }
    }
}