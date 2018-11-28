using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G = Model.Client.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Team
{
    public class DetailsForm
    {
        [Required]
        [Editable(false)]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Team Leader")]
        public G.Employee TeamLeader { get; set; }
        [Required]
        public G.Employee Creator { get; set; }
        [Required]
        public G.Project Project { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Creation date")]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public IEnumerable<G.Employee> Members { get; set; }
    }
}