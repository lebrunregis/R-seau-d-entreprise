using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D = Model.Global.Data;

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
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Deadline { get; set; }
        [HiddenInput]
        public int? SubtaskOf { get; set; }
        [HiddenInput]
        public String StatusName { get; set; }
        [HiddenInput]
        [DataType(DataType.Date)]
        public DateTime StatusDate { get; set; }
        public IEnumerable<D.TaskStatus> StatusList { get; set; }
        [Required]
        [HiddenInput]
        public int SelectedStatusId { get; set; }

    }
}