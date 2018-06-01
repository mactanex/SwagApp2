using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwagApp.Models;

namespace SwagApp2.DataStores
{
    public class FakeListStore : IListStore
    {
        private static Dictionary<string, ToDoList> _listStore;

        public FakeListStore()
        {
            if (_listStore == null)
            {
                _listStore = new Dictionary<string, ToDoList>();
            }

            _listStore["Derp List"] = new ToDoList()
            {
                Name = "Derp List",
                ListItems =
                {
                    new ListItem {Checked = false, Description = "Swag", Name = "First Item"},
                    new ListItem {Checked = false, Description = "Derp", Name = "Second Item"}
                }
            };
        }

        public Task<IEnumerable<string>> GetAllLists()
        {
            return Task.FromResult(_listStore.Select(t => t.Key));
        }

        public Task<ToDoList> GetList(string id)
        {
            Validate(id);
            ToDoList list = null;
            if (_listStore.TryGetValue(id, out list))
                return Task.FromResult(list);
            // ReSharper disable once ExpressionIsAlwaysNull
            return Task.FromResult(list);
        }

        public Task<ToDoList> CreateList(ToDoList list)
        {
            Validate(list);
            ToDoList result = null;
            if (_listStore.ContainsKey(list.Name))
                return Task.FromResult(result);

            _listStore.Add(list.Name, list);
            result = list;
            return Task.FromResult(result);
        }

        public Task<ToDoList> UpdateList(string id, ToDoList list)
        {
            Validate(id);
            Validate(list);

            ToDoList result = null;

            if(id != list.Name)
                return Task.FromResult(result);

            if (_listStore.ContainsKey(id))
            {
                _listStore[id] = list;
                result = _listStore[id];
                return Task.FromResult(result);
            }

            return Task.FromResult(result);
        }

        public Task<ToDoList> DeleteList(string id)
        {
            Validate(id);

            ToDoList result = null;

            if (_listStore.ContainsKey(id))
            {
                result = _listStore[id];
                _listStore.Remove(id);
                return Task.FromResult(result);
            }

            return Task.FromResult(result);
        }

        private void Validate(ToDoList list)
        {
            if(list == null)
                throw new ArgumentNullException(nameof(list));

            if(string.IsNullOrEmpty(list.Name))
                throw new ArgumentNullException(nameof(list.Name));
        }

        public void Validate(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
        }
    }
}
