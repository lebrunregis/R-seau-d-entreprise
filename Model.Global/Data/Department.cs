using System;

namespace Model.Global.Data
{
    public class Department
    {
        public int? Id { get; set; }
        public String Title { get; set; }
        public DateTime Created { get; set; }
        public String Description { get; set; }
        public int Admin_Id { get; set; }
        public bool Active { get; set; }
    }
}
