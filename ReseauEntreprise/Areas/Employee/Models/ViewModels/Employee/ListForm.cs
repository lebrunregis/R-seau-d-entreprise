using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectTeamsForm = ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage.ProjectTeamsForm;
using D = Model.Client.Data;

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
        public IEnumerable<ProjectTeamsForm> TeamsInCommon { get; set; }
    }
}