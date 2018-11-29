using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Department
    {
        private int? id;
        private String title;
        private DateTime created;
        private String description;
        private int admin_Id;
        private bool active;

        public Department(int? id, string title, DateTime created, string description, int admin_Id, bool active)
        {
            Id = id;
            Title = title;
            Created = created;
            Description = description;
            Admin_Id = admin_Id;
            Active = active;
        }

        public Department(string title, DateTime created, string description, int admin_Id, bool active)
        {
            Title = title;
            Created = created;
            Description = description;
            Admin_Id = admin_Id;
            Active = true;
        }

        public int? Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public DateTime Created { get => created; set => created = value; }
        public string Description { get => description; set => description = value; }
        public int Admin_Id { get => admin_Id; set => admin_Id = value; }
        public bool Active { get => active; set => active = value; }
    }
}
