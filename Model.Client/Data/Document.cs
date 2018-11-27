using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Data
{
    public class Document
    {
        private int id;
        private String name;
        private DateTime created;
        private String link;
        private float size;
        private String sHA2;
        private Boolean active;
        private int authorEmployee;
        private int nextVersion;

        public Document(int id, string name, DateTime created, string link, float size, string sHA2, bool active, int authorEmployee, int nextVersion)
        {
            Id = id;
            Name = name;
            Created = created;
            Link = link;
            Size = size;
            SHA2 = sHA2;
            Active = active;
            AuthorEmployee = authorEmployee;
            NextVersion = nextVersion;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Created { get => created; set => created = value; }
        public string Link { get => link; set => link = value; }
        public float Size { get => size; set => size = value; }
        public string SHA2 { get => sHA2; set => sHA2 = value; }
        public bool Active { get => active; set => active = value; }
        public int AuthorEmployee { get => authorEmployee; set => authorEmployee = value; }
        public int NextVersion { get => nextVersion; set => nextVersion = value; }
    }
}
