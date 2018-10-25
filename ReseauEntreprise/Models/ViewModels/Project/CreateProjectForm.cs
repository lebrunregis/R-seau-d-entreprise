using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Models.ViewModels.Project
{
    public class CreateProjectForm
    {
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public int ProjectManager { get; set; }
    }
}