using D = Model.Global.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Team
{
    public class ManageEmployeesForm
    {
        public D.Employee Employee { get; set; }
        public bool IsInTeam { get; set; }
        public IEnumerable<D.Department> Departments { get; set; }
    }
}