using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D = Model.Global.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Project
{
    public class EditForm
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [HiddenInput]
        [Required]
        public int CreatorId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Project Manager")]
        public int ProjectManagerId { get; set; }
        public IEnumerable<SelectListItem> ProjectManagerCandidateList { get; set; }
        [HiddenInput]
        [Required]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        
    }
}