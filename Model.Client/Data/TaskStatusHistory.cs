using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    class TaskStatusHistory
    {
        private int TaskId { get; set; }
        private int TaskStatusId { get; set; }
        private String StatusName { get; set; }
        private DateTime Date { get; set; }
    }
}
