using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class EmployeeEvent
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public int EmployeeId { set; get; }
        public int EventId { set; get; }
        public bool? Attended { set; get; }
        public bool? Cancelled { set; get; }
        public DateTime?  Subscribed { set; get; }
    }
}
