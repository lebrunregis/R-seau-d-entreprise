using System;

namespace Model.Client.Data
{
    public class Document
    {
        private int? id;
        private String filename;
        private DateTime created;
        private byte[] body;
        private float size;
        private String checksum;
        private Boolean active;
        private int authorEmployee;
        private int nextVersion;

        public Document()
        {

        }

        public Document(int? id, string filename, DateTime created, byte[] body, float size, string checksum, bool active, int authorEmployee, int nextVersion)
        {
            Id = id;
            Filename = filename;
            Created = created;
            Body = body;
            Size = size;
            Checksum = checksum;
            Active = active;
            AuthorEmployee = authorEmployee;
            NextVersion = nextVersion;
        }

        public int? Id { get => id; set => id = value; }
        public string Filename { get => filename; set => filename = value; }
        public DateTime Created { get => created; set => created = value; }
        public byte[] Body { get => body; set => body = value; }
        public float Size { get => size; set => size = value; }
        public string Checksum { get => checksum; set => checksum = value; }
        public bool Active { get => active; set => active = value; }
        public int AuthorEmployee { get => authorEmployee; set => authorEmployee = value; }
        public int NextVersion { get => nextVersion; set => nextVersion = value; }
    }
}
