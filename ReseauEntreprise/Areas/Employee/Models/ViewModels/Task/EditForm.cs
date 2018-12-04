using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class EditForm
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CreatorId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? SubtaskOf { get; set; }
        public String StatusName { get; set; }
        public DateTime StatusDate { get; set; }
        public int? StatusId { get; set; }
    }
}