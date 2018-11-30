using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class ProjectManagerHistory
    {
        public int Project_Id { get; set; }
        public string Project_Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
