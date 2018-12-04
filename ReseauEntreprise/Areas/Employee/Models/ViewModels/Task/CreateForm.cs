using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class CreateForm
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        [HiddenInput]
        public int? SubtaskOf { get; set; }
    }
}