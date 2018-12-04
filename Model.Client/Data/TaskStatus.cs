using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class TaskStatus
    {
        private int _id;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public String Name { get => _name; set => _name = value; }
    }
}
