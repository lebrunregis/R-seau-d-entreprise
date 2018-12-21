using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Team
{
    public class DeleteForm
    {
        [Key]
        [HiddenInput]
        [Editable(false)]
        [Display(Name = "Team")]
        public int Team_Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Editable(false)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Editable(false)]
        public DateTime Created { get; set; }
        [Required]
        [Editable(false)]
        [Display(Name = "Created by")]
        public int Creator_Id { get; set; }
        [Required]
        [Editable(false)]
        [Display(Name = "Project")]
        public int Project_Id { get; set; }
    }
}