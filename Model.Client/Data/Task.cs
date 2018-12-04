using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Task
    {
        private int? id;
        private String name;
        private String description;
        private DateTime startDate;
        private DateTime? endDate;
        private DateTime? deadline;
        private int? subtaskOf;
        private int? statusId;
        private string statusName;
        private DateTime? statusDate;

        public Task()
        {

        }

        public Task( int? id, string name, string description, DateTime startDate, DateTime? endDate, DateTime? deadline, int? subtaskOf,string statusName,DateTime statusDate)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Deadline = deadline;
            SubtaskOf = subtaskOf;
            StatusName = statusName;
            StatusDate = statusDate;
        }

        public int? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime? EndDate { get => endDate; set => endDate = value; }
        public DateTime? Deadline { get => deadline; set => deadline = value; }
        public int? SubtaskOf { get => subtaskOf; set => subtaskOf = value; }
        public int? StatusId { get => statusId; set => statusId = value; }
        public string StatusName { get => statusName; set => statusName = value; }
        public DateTime? StatusDate { get => statusDate; set => statusDate = value; }
        
    }
}
