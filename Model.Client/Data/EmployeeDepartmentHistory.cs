using System;

namespace Model.Client.Data
{
    public class EmployeeDepartmentHistory
    {
        private int? id;
        private string name;
        private int depId;
        private DateTime startDate;
        private DateTime? endDate;

        public EmployeeDepartmentHistory()
        {

        }

        public EmployeeDepartmentHistory(int? id, string name, int depId, DateTime startDate, DateTime? endDate)
        {
            Id = id;
            Name = name;
            DepId = depId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public EmployeeDepartmentHistory(string name, int depId, DateTime startDate, DateTime? endDate)
        {
            Name = name;
            DepId = depId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int DepId { get => depId; set => depId = value; }
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
                    throw new ArgumentOutOfRangeException("End", "The Department membership cannot end before it has started");
                }

            }
        }
    }
}
