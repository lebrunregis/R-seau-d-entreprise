using System;

namespace Model.Client.Data
{
    public class Message
    {
        private int? id;
        private String title;
        private DateTime created;
        private String body;
        private int author;
        private int? parent;

        public Message()
        {
        }

        public Message(int? id, string title, DateTime created, string body, int author, int? parent)
        {
            Id = id;
            Title = title;
            Created = created;
            Body = body;
            Author = author;
            Parent = parent;
        }

        public Message(string title, string body, int author, int? parent)
        {
            Id = id;
            Title = title;
            Created = DateTime.Now;
            Body = body;
            Author = author;
            Parent = parent;
        }

        public int? Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public DateTime Created { get => created; set => created = value; }
        public string Body { get => body; set => body = value; }
        public int Author { get => author; set => author = value; }
        public int? Parent { get => parent; set => parent = value; }
    }
}
