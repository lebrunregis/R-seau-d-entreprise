using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D = Model.Client.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Project
{
    public class DeleteForm
    {
        [Key]
        [HiddenInput]
        [Editable(false)]
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        [Editable(false)]
        [Display(Name = "Project Name")]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Editable(false)]
        public String Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Editable(false)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Editable(false)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Required]
        [HiddenInput]
        [Editable(false)]
        [Display(Name = "Project Manager")]
        public D.Employee ProjectManager { get; set; }
        [Required]
        [HiddenInput]
        [Editable(false)]
        [Display(Name = "Creator")]
        public D.Employee Creator { get; set; }

        public DeleteForm()
        {
        }

        public DeleteForm(D.Project Project,D.Employee ProjectManager, D.Employee Creator)
        {
            ProjectId = (int) Project.Id;
            Name = Project.Title;
            Description = Project.Description;
            StartDate = Project.Start;
            EndDate = Project.End;
            this.ProjectManager = ProjectManager;
            this.Creator = Creator;
        }
    }
}