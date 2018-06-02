using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwagApp.Models;

namespace SwagApp2.DataStores
{
    public interface IListStore
    {
        Task<IEnumerable<string>> GetAllListsAsync();
        Task<ToDoList> GetListAsync(string id);
        Task<ToDoList> CreateListAsync(ToDoList list);
        Task<ToDoList> UpdateListAsync(string id, ToDoList list);
        Task<ToDoList> DeleteListAsync(string id);
    }
}