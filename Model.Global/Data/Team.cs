using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Team
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime Created { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
