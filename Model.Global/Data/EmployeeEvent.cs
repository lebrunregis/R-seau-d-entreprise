using System;

namespace Model.Global.Data
{
    public class EmployeeEvent
    {
        public int EmployeeId { set; get; }
        public int EventId { set; get; }
        public bool? Attended { set; get; }
        public bool? Cancelled { set; get; }
        public DateTime?  Subscribed { set; get; }
    }
}
