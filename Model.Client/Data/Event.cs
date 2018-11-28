using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Event
    {
        private int? id;
        private int creatorId;
        private int? departmentId;
        private string name;
        private string description;
        private string address;
        private DateTime startDate;
        private DateTime endDate;
        private DateTime creationDate;
        private DateTime? subscribed;
        private bool open;
        private bool cancelled;

        public Event(int? id, int creatorId, int? departmentId, string name, string description, string address, DateTime startDate, DateTime endDate, DateTime creationDate, DateTime? subscribed, bool open, bool cancelled)
        {
            Id = id;
            CreatorId = creatorId;
            DepartmentId = departmentId;
            Name = name;
            Description = description;
            Address = address;
            StartDate = startDate;
            EndDate = endDate;
            CreationDate = creationDate;
            Subscribed = subscribed;
            Open = open;
            Cancelled = cancelled;
        }

        public Event( int creatorId, int? departmentId, string name, string description, string address, DateTime startDate, DateTime endDate, bool open)
        {
            CreatorId = creatorId;
            DepartmentId = departmentId;
            Name = name;
            Description = description;
            Address = address;
            StartDate = startDate;
            EndDate = endDate;
            CreationDate = DateTime.Now;
            Open = open;
            Cancelled = false;
        }

        public int? Id { get => id; set => id = value; }
        public int CreatorId { get => creatorId; set => creatorId = value; }
        public int? DepartmentId { get => departmentId; set => departmentId = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Address { get => address; set => address = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                if (DateTime.Compare((DateTime)value, StartDate) <= 0)
                {
                    endDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("End", "The event cannot end before it has started");
                }

            }
        }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public DateTime? Subscribed { get => subscribed; set => subscribed = value; }
        public bool Open { get => open; set => open = value; }
        public bool Cancelled { get => cancelled; set => cancelled = value; }
    }
}
