using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwagApp.Models;

namespace SwagApp2.DataStores
{
    public interface IListStore
    {
        Task<IEnumerable<string>> GetAllLists();
        Task<ToDoList> GetList(string id);
        Task<ToDoList> CreateList(ToDoList list);
        Task<ToDoList> UpdateList(string id, ToDoList list);
        Task<ToDoList> DeleteList(string id);
    }
}