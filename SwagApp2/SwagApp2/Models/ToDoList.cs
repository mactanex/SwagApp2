using System.Collections.Generic;

namespace SwagApp.Models
{
    public class ToDoList
    {
        public string Name { get; set; }
        public List<ListItem> ListItems { get; set; }

        public ToDoList()
        {
            ListItems = new List<ListItem>();
        }
    }
}