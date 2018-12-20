using System;

namespace Model.Client.Data
{
    public class Project
    {
        private int? id;
        private String title;
        private String description;
        private DateTime start;
        private DateTime? end;
        private int creatorId;
        private int projectManagerId;

        public Project()
        {

        }

        public Project(int? id, string title, string description, DateTime start, DateTime? end, int creatorId, int projectManagerId)
        {
            Id = id;
            Title = title;
            Description = description;
            Start = start;
            End = end;
            CreatorId = creatorId;
            ProjectManagerId = projectManagerId;
        }

        public Project( string title, string description, DateTime start, DateTime? end, int creatorId, int projectManagerId)
        {
            Title = title;
            Description = description;
            Start = start;
            End = end;
            CreatorId = creatorId;
            ProjectManagerId = projectManagerId;
        }

        public int? Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value.Normalize(); }
        public DateTime Start { get => start; set => start = value; }
        public DateTime? End
        {
            get
            {
                return end;
            }

            set
            {
                if (value is null || DateTime.Compare((DateTime)value, Start) >= 0)
                {
                    end = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("End", "The project cannot end before it has started");
                }

            }
        }
        public int CreatorId { get => creatorId; set => creatorId = value; }
        public int ProjectManagerId { get => projectManagerId; set => projectManagerId = value; }
    }
}
