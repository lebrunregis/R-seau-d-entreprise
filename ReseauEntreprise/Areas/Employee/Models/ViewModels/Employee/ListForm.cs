using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectTeams = ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage.ProjectTeams;
using D = Model.Global.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Employee
{
    public class ListForm
    {
        [Key]
        public int Id { get; set; }
        public bool IsMe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<D.Department> Departments { get; set; }
        public IEnumerable<ProjectTeams> TeamsInCommon { get; set; }
    }
}