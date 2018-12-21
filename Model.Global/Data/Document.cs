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
        public long Size { get; set; }
        public int Checksum { get; set; }
        public int AuthorEmployee { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
