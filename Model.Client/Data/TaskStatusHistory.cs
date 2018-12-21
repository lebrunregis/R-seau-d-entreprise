using System;

namespace Model.Client.Data
{
    public class TaskStatusHistory
    {
        private int _taskId;
        private int _taskStatusId;
        private string _statusName;
        private DateTime _date;

        public TaskStatusHistory(int taskId,int taskStatusId,string statusName,DateTime date)
        {
            TaskId = taskId;
            TaskStatusId = taskStatusId;
            StatusName = statusName;
            Date = date;
        }

        public int TaskId { get => _taskId; set => _taskId = value; }
        public int TaskStatusId { get => _taskStatusId; set => _taskStatusId = value; }
        public String StatusName { get => _statusName; set => _statusName = value; }
        public DateTime Date { get => _date; set => _date = value; }


    }
}
