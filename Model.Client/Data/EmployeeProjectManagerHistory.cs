using System;

namespace Model.Client.Data
{
    public class ProjectManagerHistory
    {
        private int project_Id;
        private string project_Name;
        private DateTime startDate;
        private DateTime? endDate;

        public ProjectManagerHistory()
        {

        }

        public ProjectManagerHistory(int project_Id, string project_Name, DateTime startDate, DateTime? endDate)
        {
            Project_Id = project_Id;
            Project_Name = project_Name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Project_Id { get => project_Id; set => project_Id = value; }
        public string Project_Name { get => project_Name; set => project_Name = value; }
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
                    throw new ArgumentOutOfRangeException("End", "The management period cannot end before it has started");
                }

            }
        }
    }
}
