using System;

namespace Model.Global.Data
{
    public class TaskStatusHistory
    {
        public int TaskId { get; set; }
        public int TaskStatusId { get; set; }
        public String StatusName { get; set; }
        public DateTime Date { get; set; }
    }
}
