using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Task
{
    public class CreateForm
    {
        public int? ProjectId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? SubtaskOf { get; set; }
    }
}