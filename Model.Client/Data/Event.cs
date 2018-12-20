using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    [DataContract]
    public class Event
    {
        
        private int? id;
        private int creatorId;
        private int? departmentId;
        private string name;
        private string description;
        private string address;
        private DateTime start;
        private DateTime end;
        private DateTime created;
        private DateTime? subscribed;
        private bool open;
        private bool cancelled;

        public Event()
        {

        }

        public Event(int? id, int creatorId, int? departmentId, string title, string description, string address, DateTime start, DateTime end, DateTime created, DateTime? subscribed, bool open, bool cancelled)
        {
            Id = id;
            CreatorId = creatorId;
            DepartmentId = departmentId;
            Title = title;
            Description = description;
            Address = address;
            Start = start;
            End = end;
            Created = created;
            Subscribed = subscribed;
            Open = open;
            Cancelled = cancelled;
        }

        public Event( int creatorId, int? departmentId, string title, string description, string address, DateTime start, DateTime end, bool open)
        {
            CreatorId = creatorId;
            DepartmentId = departmentId;
            Title = title;
            Description = description;
            Address = address;
            Start = start;
            End = end;
            Open = open;
            Cancelled = false;
        }

        public int? Id { get => id; set => id = value; }
        public int CreatorId { get => creatorId; set => creatorId = value; }
        public int? DepartmentId { get => departmentId; set => departmentId = value; }
        [DataMember]
        public string Title { get => name; set => name = value; }
        [DataMember]
        public string Description { get => description; set => description = value; }
        public string Address { get => address; set => address = value; }
        [DataMember]
        public DateTime Start { get => start; set => start = value; }
        [DataMember]
        public DateTime End
        {
            get
            {
                return end;
            }

            set
            {
                if (DateTime.Compare((DateTime)value, Start) >= 0)
                {
                    end = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("End", "The event cannot end before it has started");
                }

            }
        }
        public DateTime Created { get => created; set => created = value; }
        public DateTime? Subscribed { get => subscribed; set => subscribed = value; }
        public bool Open { get => open; set => open = value; }
        public bool Cancelled { get => cancelled; set => cancelled = value; }
    }
}
