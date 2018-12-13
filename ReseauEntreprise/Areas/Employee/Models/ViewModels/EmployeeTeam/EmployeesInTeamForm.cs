using D = Model.Client.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.EmployeeTeam
{
    public class EmployeesInTeamForm
    {
        public D.Team Team { get; set; }
        public IEnumerable<EmployeeTeamForm> Employees { get; set; }
    }
}