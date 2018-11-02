﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Project
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int CreatorId { get; set; }
    }
}
