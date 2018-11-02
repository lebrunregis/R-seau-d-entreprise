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
        [Editable(false)]
        private int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        [Editable(false)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Editable(false)]
        public String Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Editable(false)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Editable(false)]
        public DateTime? EndDate { get; set; }
        [Required]
        [HiddenInput]
        [Editable(false)]
        D.Employee ProjectManager { get; set; }
        [Required]
        [HiddenInput]
        [Editable(false)]
        D.Employee Creator { get; set; }

        public DeleteForm(D.Project Project,D.Employee ProjectManager, D.Employee Creator)
        {
            ProjectId = Project.Id;
            Name = Project.Name;
            Description = Project.Description;
            StartDate = Project.Start;
            EndDate = Project.End;
            this.ProjectManager = ProjectManager;
            this.Creator = Creator;
        }
    }
}