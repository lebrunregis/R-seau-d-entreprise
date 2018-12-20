using System;

namespace Model.Client.Data
{
    public class Task
    {
        private int? id;
        private int projectId;
        private int creatorId;
        private int? teamId;
        private String title;
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

        public Task( int projectId, int creatorId, int? teamId, string title, string description, DateTime startDate, DateTime? endDate, DateTime? deadline, int? subtaskOf)
        {
            ProjectId = projectId;
            CreatorId = creatorId;
            TeamId = teamId;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Deadline = deadline;
            SubtaskOf = subtaskOf;
        }

        public Task(int id, int projectId, int creatorId, int? teamId, string title, string description, DateTime startDate, DateTime? endDate, DateTime? deadline, int? subtaskOf,string statusName,DateTime? statusDate,int statusId)
        {
            Id = id;
            ProjectId = projectId;
            CreatorId = creatorId;
            TeamId = teamId;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Deadline = deadline;
            SubtaskOf = subtaskOf;
            this.statusName = statusName;
            this.statusDate = statusDate;
            this.statusId = statusId;
        }

        public int? Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
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
        public int? TeamId { get => teamId; set => teamId = value; }
    }
}
