using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Document
    {
        private int? id;
        private String name;
        private DateTime created;
        private byte[] body;
        private long size;
        private int checksum;
        private int authorEmployee;
        private DateTime? deleted;

        public Document()
        {

        }

        public Document(int? id, string name, DateTime created, byte[] body, long size, int checksum, int authorEmployee, DateTime? deleted)
        {
            Id = id;
            Name = name;
            Created = created;
            Body = body;
            Size = size;
            Checksum = checksum;
            AuthorEmployee = authorEmployee;
            Deleted = deleted;
        }

        public int? Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Created { get => created; set => created = value; }
        public byte[] Body { get => body; set => body = value; }
        public long Size { get => size; set => size = value; }
        public int Checksum { get => checksum; set => checksum = value; }
        public int AuthorEmployee { get => authorEmployee; set => authorEmployee = value; }
        public DateTime? Deleted { get => deleted; set => deleted = value; }
    }
}
