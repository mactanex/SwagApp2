using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwagApp2.Models;

namespace SwagApp2.DataStores
{
    public class FakeListStore : IListStore
    {
        private readonly Dictionary<string, ToDoList> _listStore;

        public FakeListStore()
        {
            _listStore = new Dictionary<string, ToDoList>
            {
                ["Derp List"] = new ToDoList("Derp List")
                {
                    Owner = "Jonas Nedergaard Andersen",
                    Created = DateTime.Now,
                    ListItems =
                    {
                        new ListItem {Checked = false, Description = "Swag", Name = "First Item"},
                        new ListItem {Checked = false, Description = "Derp", Name = "Second Item"}
                    }
                },
                ["Dope List"] = new ToDoList("Dope List")
                {
                    Owner = "Bella Terragni",
                    Created = DateTime.Now.AddMinutes(-100),
                    ListItems =
                    {
                        new ListItem {Checked = false, Description = "Swag", Name = "First Item"},
                        new ListItem {Checked = false, Description = "Derp", Name = "Second Item"}
                    }
                }
            };


        }

        public Task<IEnumerable<ToDoList>> GetAllListsAsync()
        {
            var result = _listStore.Values.OrderByDescending(l => l.Created);
            return Task.FromResult((IEnumerable<ToDoList>) result);
        }

        public Task<ToDoList> GetListAsync(string id)
        {
            Validate(id);
            ToDoList list = null;
            if (_listStore.TryGetValue(id, out list))
                return Task.FromResult(list);
            // ReSharper disable once ExpressionIsAlwaysNull
            return Task.FromResult(list);
        }

        public Task<ToDoList> CreateListAsync(ToDoList list)
        {
            Validate(list);
            ToDoList result = null;
            if (_listStore.ContainsKey(list.Name))
                return Task.FromResult(result);

            _listStore.Add(list.Name, list);
            result = list;
            return Task.FromResult(result);
        }

        public Task<ToDoList> UpdateListAsync(string id, ToDoList list)
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

        public Task<ToDoList> DeleteListAsync(string id)
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
