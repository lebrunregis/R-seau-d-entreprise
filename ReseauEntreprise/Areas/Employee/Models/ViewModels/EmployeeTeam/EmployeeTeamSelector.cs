using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.EmployeeTeam
{
    public class EmployeeTeamSelector
    {
        public int EmployeeId { get; set; }
        public int TeamId { get; set; }
        public bool IsInTeam { get; set; }
    }
}