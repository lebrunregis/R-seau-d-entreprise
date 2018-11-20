using D = Model.Global.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.EmployeeTeam
{
    public class EmployeesInTeamForm
    {
        [DisplayName("Employé")]
        public D.Employee Employee { get; set; }
        [DisplayName("Departements")]
        public IEnumerable<D.Department> Departments { get; set; }
        [DisplayName("Dans cette équipe")]
        public bool IsInTeam { get; set; }
    }
}