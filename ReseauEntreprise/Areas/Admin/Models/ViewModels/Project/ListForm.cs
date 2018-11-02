using D = Model.Global.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Admin.Models.ViewModels.Project
{
    public class ListForm
    {
        [HiddenInput]
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
        public D.Employee Manager { get; set; }


        public ListForm(D.Project Project,D.Employee Manager)
        {
            ProjectId = Project.Id;
            Name = Project.Name;
            Description = Project.Description;
            this.Manager = Manager;
        }
    }
}