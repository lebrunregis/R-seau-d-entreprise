using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Data
{
    public class Document
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public DateTime Created { get; set; }
        public byte[] Body { get; set; }
        public float Size { get; set; }
        public String SHA2 { get; set; }
        public Boolean Active { get; set; }
        public int AuthorEmployee { get; set; }
        public int NextVersion { get; set; }
    }
}
