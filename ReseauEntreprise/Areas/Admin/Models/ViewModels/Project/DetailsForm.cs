using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Project
{
    public class DetailsForm
    {
        [Required]
        [Editable(false)]
        [HiddenInput]
        [Display(Name = "Project Id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Project Name")]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Project Manager")]
        public C.Employee Manager { get; set; }
        [Required]
        [Display(Name = "Creator")]
        public C.Employee Creator { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Teams")]
        public IEnumerable<C.Team> Teams { get; set; }
    }
}