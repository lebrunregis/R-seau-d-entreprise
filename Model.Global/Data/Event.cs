using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Event
    {
        public int? Id { get; set; }
        public int CreatorId { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? Subscribed { get; set; }
        public bool Open { get; set; }
        public bool Cancelled { get; set; }
    }
}
