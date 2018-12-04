using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
   public class TaskStatusHistory
    {
        public int TaskId { get; set; }
        public int TaskStatusId { get; set; }
        public String StatusName { get; set; }
        public DateTime Date { get; set; }
    }
}
