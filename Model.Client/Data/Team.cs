using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Team
    {
        private int? id;
        private String name;
        private DateTime created;
        private DateTime? disbanded;
        private int creator_Id;
        private int project_Id;
        private List<Employee> employees;

        public Team(int? id, string name, DateTime created, DateTime? disbanded, int creator_Id, int project_Id, List<Employee> employees)
        {
            Id = id;
            Name = name;
            Created = created;
            Disbanded = disbanded;
            Creator_Id = creator_Id;
            Project_Id = project_Id;
            Employees = employees;
        }


        public Team(string name, int creator_Id, int project_Id)
        {
            Name = name;
            Created = DateTime.Now;
            Creator_Id = creator_Id;
            Project_Id = project_Id;
        }

        public int? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Created { get => created; set => created = value; }
        public DateTime? Disbanded { get => disbanded; set => disbanded = value; }
        public int Creator_Id { get => creator_Id; set => creator_Id = value; }
        public int Project_Id { get => project_Id; set => project_Id = value; }
        public List<Employee> Employees { get => employees; set => employees = value; }
    }
}
