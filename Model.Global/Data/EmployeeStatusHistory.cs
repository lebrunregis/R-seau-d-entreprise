using System;

namespace Model.Global.Data
{
    public class EmployeeStatusHistory
    {
        public int? Id { get; set; }
        public int Employee { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
