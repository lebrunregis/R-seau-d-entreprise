using System;

namespace Model.Global.Data
{
    public class ProjectManagerHistory
    {
        public int Project_Id { get; set; }
        public string Project_Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
