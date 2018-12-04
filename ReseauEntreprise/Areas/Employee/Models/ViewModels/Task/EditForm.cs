using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class EditForm
    {
        [Key]
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [HiddenInput]
        public int ProjectId { get; set; }
        [Required]
        [HiddenInput]
        public int CreatorId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public DateTime? Deadline { get; set; }
        [HiddenInput]
        public int? SubtaskOf { get; set; }
        [HiddenInput]
        public String StatusName { get; set; }
        [HiddenInput]
        public DateTime StatusDate { get; set; }
        [Required]
        public int? StatusId { get; set; }
    }
}