using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models
{
    public class ProjectModel
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Editable(false)]
        public DateTime Start { get; set; }
        [Editable(false)]
        public DateTime? End { get; set; }
        [HiddenInput]
        public int Creator { get; set; }
        [Editable(false)]
        public String CreatorName { get; set; }
        [Editable(false)]
        public String CreatorLastName { get; set; }
    }
}