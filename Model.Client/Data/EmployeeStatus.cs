using System;

namespace Model.Client.Data
{
    public class EmployeeStatus
    {
        private int id;
        private String name;

        public EmployeeStatus()
        {

        }

        public EmployeeStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
