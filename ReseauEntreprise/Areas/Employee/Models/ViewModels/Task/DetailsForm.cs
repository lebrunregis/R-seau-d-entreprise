using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C = Model.Client.Data;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class DetailsForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        [Required]
        [Display(Name = "Created by")]
        public int CreatorId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        [Display(Name = "Subtask of")]
        public int? SubtaskOf { get; set; }
        [Required]
        [Display(Name = "Status")]
        public String StatusName { get; set; }
        [Required]
        public DateTime StatusDate { get; set; }
        [Required]
        public int StatusId { get; set; }
        public IEnumerable<Doc.ListForm> Documents { get; set; }


        public Message.DiscussionScriptForm DiscScriptForm { get; set; }
        public C.Task Parent { get; set; }
        public IEnumerable<C.Task> Subtasks { get; set; }
    }
}