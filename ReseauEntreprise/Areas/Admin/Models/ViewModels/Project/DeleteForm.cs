using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D = Model.Global.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Project
{
    public class DeleteForm
    {
        [Key]
        [HiddenInput]
        private int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        public DeleteForm(D.Project Project,D.Employee ProjectManager)
        {
            ProjectId = Project.Id;
            Name = Project.Name;
            Description = Project.Description;
        }
    }
}