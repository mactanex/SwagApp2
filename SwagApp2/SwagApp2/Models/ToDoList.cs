using System;
using System.Collections.Generic;

namespace SwagApp2.Models
{
    public class ToDoList
    {
        public string Name { get; set; }
        public List<ListItem> ListItems { get; set; }
        public string Owner { get; set; }
        public DateTime Created { get; set; }
        public ToDoList(string name)
        {
            ListItems = new List<ListItem>();
            Created = DateTime.Now;
            Name = name;
        }
    }
}