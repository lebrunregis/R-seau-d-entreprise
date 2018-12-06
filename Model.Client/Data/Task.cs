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
        private int projectId;
        private int creatorId;
        private int teamId;
        private String name;
        private String description;
        private DateTime startDate;
        private DateTime? endDate;
        private DateTime? deadline;
        private int? subtaskOf;
        private readonly int? statusId;
        private readonly string statusName;
        private readonly DateTime? statusDate;

        public Task()
        {

        }

        public Task( int projectId, int creatorId, int teamId, string name, string description, DateTime startDate, DateTime? endDate, DateTime? deadline, int? subtaskOf)
        {
            ProjectId = projectId;
            CreatorId = creatorId;
            TeamId = teamId;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Deadline = deadline;
            SubtaskOf = subtaskOf;
        }

        public Task(int id, int projectId, int creatorId, int teamId, string name, string description, DateTime startDate, DateTime? endDate, DateTime? deadline, int? subtaskOf,string statusName,DateTime? statusDate)
        {
            Id = id;
            ProjectId = projectId;
            CreatorId = creatorId;
            TeamId = teamId;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Deadline = deadline;
            SubtaskOf = subtaskOf;
            this.statusName = statusName;
            this.statusDate = statusDate;
        }

        public int? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime? EndDate { get => endDate; set => endDate = value; }
        public DateTime? Deadline { get => deadline; set => deadline = value; }
        public int? SubtaskOf { get => subtaskOf; set => subtaskOf = value; }
        public int? StatusId { get => statusId;  }
        public string StatusName { get => statusName; }
        public DateTime? StatusDate { get => statusDate;  }
        public int ProjectId { get => projectId; set => projectId = value; }
        public int CreatorId { get => creatorId; set => creatorId = value; }
        public int TeamId { get => teamId; set => teamId = value; }
    }
}
