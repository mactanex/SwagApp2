using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool RemoveItem(string itemName)
        {
            var newList = ListItems.Where(l => l.Name != itemName).ToList();
            if (newList.Count == ListItems.Count)
                return false;

            ListItems = newList;
            return true;
        }

        public bool AddItem(ListItem item)
        {
            if (ListItems.FirstOrDefault(i => i.Name == item.Name) == null)
            {
                ListItems.Add(item);
                return true;
            }

            return false;
        }
    }
}