using C = Model.Client.Data;
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
        public C.Employee Manager { get; set; }
        [HiddenInput]
        [Required]
        public C.Employee Creator { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate;
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate;


        public ListForm()
        {

        }

        public ListForm(C.Project Project,C.Employee Manager, C.Employee Creator)
        {
            ProjectId = (int) Project.Id;
            Name = Project.Name;
            Description = Project.Description;
            this.Manager = Manager;
            this.Creator = Creator;
            this.StartDate = Project.Start;
            this.EndDate = Project.End;
        }
    }
}