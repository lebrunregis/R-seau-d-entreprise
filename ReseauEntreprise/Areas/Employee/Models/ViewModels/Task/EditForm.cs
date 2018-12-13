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
        [HiddenInput]
        public int TeamId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Deadline { get; set; }
        [HiddenInput]
        public int? SubtaskOf { get; set; }
        [HiddenInput]
        [DataType(DataType.Date)]
        public List<SelectListItem> StatusList { get; set; }
        [Required]
        [HiddenInput]
        public int SelectedStatusId { get; set; }
    }
}