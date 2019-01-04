using System.Collections.Generic;
using System.ComponentModel;
using D = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.EmployeeTeam
{
    public class EmployeeTeamSelector
    {
        [DisplayName("Team")]
        public D.Team Team { get; set; }
        [DisplayName("Employé")]
        public D.Employee Employee { get; set; }
        [DisplayName("Departements")]
        public IEnumerable<D.Department> Departments { get; set; }
        [DisplayName("Dans cette équipe")]
        public bool IsInTeam { get; set; }
    }
}