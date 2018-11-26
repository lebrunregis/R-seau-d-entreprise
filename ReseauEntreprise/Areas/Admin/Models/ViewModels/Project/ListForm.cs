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
        [Required]
        [HiddenInput]
        [Key]
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Project Name")]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public String Description { get; set; }
        [HiddenInput]
        [Required]
        [Display(Name = "Project Manager")]
        public D.Employee Manager { get; set; }
        [HiddenInput]
        [Required]
        public D.Employee Creator { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate;
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate;


        public ListForm()
        {

        }

        public ListForm(D.Project Project,D.Employee Manager, D.Employee Creator)
        {
            ProjectId = Project.Id;
            Name = Project.Name;
            Description = Project.Description;
            this.Manager = Manager;
            this.Creator = Creator;
            this.StartDate = Project.Start;
            this.EndDate = Project.End;
        }
    }
}