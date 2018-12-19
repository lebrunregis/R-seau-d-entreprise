using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using D = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.EmployeeTeam
{
    public class EmployeeTeamSelector
    {
        [DisplayName("Team")]
        public D.Team Team { get; set; }
        [DisplayName("Employee")]
        public D.Employee Employee { get; set; }
        [DisplayName("Departments")]
        public IEnumerable<D.Department> Departments { get; set; }
        [DisplayName("In team")]
        public bool IsInTeam { get; set; }
    }
}