using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Project
    {
        private int? id;
        private String name;
        private String description;
        private DateTime start;
        private DateTime? end;
        private int creatorId;
        private int projectManagerId;

        public Project()
        {

        }

        public Project(int? id, string name, string description, DateTime start, DateTime? end, int creatorId, int projectManagerId)
        {
            Id = id;
            Name = name;
            Description = description;
            Start = start;
            End = end;
            CreatorId = creatorId;
            ProjectManagerId = projectManagerId;
        }

        public Project( string name, string description, DateTime start, DateTime? end, int creatorId, int projectManagerId)
        {
            Name = name;
            Description = description;
            Start = start;
            End = end;
            CreatorId = creatorId;
            ProjectManagerId = projectManagerId;
        }

        public int? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
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
