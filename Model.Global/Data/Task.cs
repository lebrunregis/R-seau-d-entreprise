﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Task
    {
        public int? Id { get; set; }
        public int? ProjectId { get; set; }
        public int CreatorId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? SubtaskOf { get; set; }
        public String Status { get; set; }
        public int? StatusId { get; set; }
        public String Users { get; set; }
    }
}
