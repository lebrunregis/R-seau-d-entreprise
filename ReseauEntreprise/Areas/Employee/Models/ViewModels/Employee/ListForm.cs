﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectTeamsForm = ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage.ProjectTeamsForm;
using D = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Employee
{
    public class ListForm
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Me")]
        public bool IsMe { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<D.Department> Departments { get; set; }
        [Display(Name = "Teams in common")]
        public IEnumerable<ProjectTeamsForm> TeamsInCommon { get; set; }
    }
}