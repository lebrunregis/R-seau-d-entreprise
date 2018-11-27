using D = Model.Global.Data;
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
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public bool AmIProjectManager { get; set; }


        public ListForm()
        {

        }

        public ListForm(D.Project Project,D.Employee Manager, int MyId)
        {
            ProjectId = Project.Id;
            Name = Project.Name;
            Description = Project.Description;
            this.Manager = Manager;
            this.StartDate = Project.Start;
            this.EndDate = Project.End;
            AmIProjectManager = (MyId == Manager.Employee_Id);
        }
    }
}