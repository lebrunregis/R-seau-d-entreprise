﻿using System;

namespace Model.Client.Data
{
    public class TaskStatus
    {
        private int _id;
        private string _name;

        public TaskStatus(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get => _id; set => _id = value; }
        public String Name { get => _name; set => _name = value; }
    }
}
