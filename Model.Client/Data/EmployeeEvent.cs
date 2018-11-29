using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class EmployeeEvent
    {
        private int employeeId;
        private int eventId;
        private bool? attended;
        private bool? cancelled;
        private DateTime? subscribed;

        public EmployeeEvent(int employeeId, int eventId, bool? attended, bool? cancelled, DateTime? subscribed)
        {
            EmployeeId = employeeId;
            EventId = eventId;
            Attended = attended;
            Cancelled = cancelled;
            Subscribed = subscribed;
        }

        public EmployeeEvent(int employeeId, int eventId)
        {
            EmployeeId = employeeId;
            EventId = eventId;
        }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public int EventId { get => eventId; set => eventId = value; }
        public bool? Attended { get => attended; set => attended = value; }
        public bool? Cancelled { get => cancelled; set => cancelled = value; }
        public DateTime? Subscribed { get => subscribed; set => subscribed = value; }
    }
}
