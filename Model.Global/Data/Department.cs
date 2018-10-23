using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Department
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime Created { get; set; }
        public String Description { get; set; }
        public int Admin_Id { get; set; }
    }
}
