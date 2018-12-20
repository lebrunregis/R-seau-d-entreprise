using D = Model.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Project
{
    public class ListForm
    {
        [Required]
        [Key]
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required]
        public D.Employee Manager { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime? EndDate { get; set; }
        public bool IsProjectManager { get; set; }


        public ListForm()
        {

        }

        public ListForm(D.Project Project,D.Employee Manager, int MyId)
        {
            ProjectId = (int)Project.Id;
            Name = Project.Title;
            Description = Project.Description;
            this.Manager = Manager;
            this.StartDate = Project.Start;
            this.EndDate = Project.End;
            IsProjectManager = (MyId == Manager.Employee_Id);
        }
    }
}