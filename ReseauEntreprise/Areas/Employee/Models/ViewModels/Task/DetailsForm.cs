using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class DetailsForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? SubtaskOf { get; set; }
        [Required]
        public String StatusName { get; set; }
        [Required]
        public DateTime StatusDate { get; set; }
        [Required]
        public int StatusId { get; set; }
        C.Task Parent { get; set; }
        IEnumerable<C.Task> Subtasks { get; set; }
    }
}