using D = Model.Client.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.EmployeeTeam
{
    public class EmployeesInTeamForm
    {
        public D.Employee Employee { get; set; }
        public IEnumerable<D.Department> Departments { get; set; }
        [DisplayName("Is in team")]
        public bool IsInTeam { get; set; }
    }
}