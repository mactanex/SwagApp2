using System.Threading.Tasks;

namespace SwagApp2.DataStores
{
    public interface IApplicationUserService
    {
        string DisplayName { get; set; }
        string Name { get; set; }
        Task SaveUserDataAsync();
    }
}