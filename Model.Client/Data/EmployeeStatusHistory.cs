using System;

namespace Model.Client.Data
{
    public class EmployeeStatusHistory
    {
        private int? id;
        private int employee;
        private int status;
        private string name;
        private DateTime startDate;
        private DateTime? endDate;

        public EmployeeStatusHistory()
        {

        }

        public EmployeeStatusHistory(int? id, int employee, int status, string name, DateTime startDate, DateTime? endDate)
        {
            Id = id;
            Employee = employee;
            Status = status;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public EmployeeStatusHistory(int employee, int status, string name, DateTime startDate, DateTime? endDate)
        {
            Employee = employee;
            Status = status;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int? Id { get => id; set => id = value; }
        public int Employee { get => employee; set => employee = value; }
        public int Status { get => status; set => status = value; }
        public string Name { get => name; set => name = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                if (value is null || DateTime.Compare((DateTime)value, StartDate) >= 0)
                {
                    endDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("End", "The status cannot end before it has started");
                }

            }
        }

    }
}
