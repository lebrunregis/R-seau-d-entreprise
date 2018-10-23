using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Message
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime Created { get; set; }
        public String Body { get; set; }
        public int Author { get; set; }
        public int Parent { get; set; }
    }
}
