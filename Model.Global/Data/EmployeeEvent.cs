using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    class EmployeeEvent
    {
        public int EmployeeId { set; get; }
        public int EventId { set; get; }
        public bool Attended { set; get; }
        public bool Cancelled { set; get; }
        public DateTime  Subscribed { set; get; }
    }
}
