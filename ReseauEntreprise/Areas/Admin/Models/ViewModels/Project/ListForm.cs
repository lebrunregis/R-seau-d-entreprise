using D = Model.Global.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Admin.Models.ViewModels.Project
{
    public class ListProjectForm
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [HiddenInput]
        [Required]
        public int ProjectManager { get; set; }
        [Required]
        String ProjectManagerFullName { get; set; }


        public ListProjectForm(D.Project Project)
        {
            ProjectId = Project.Id;
            Name = Project.Name;
            Description = Project.Description;
            ProjectManager = Project.Creator;
            ProjectManagerFullName = Project.CreatorFirstName + ' ' + Project.CreatorLastName;
        }
    }
}