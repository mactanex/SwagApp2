using System.Threading.Tasks;

namespace SwagApp2.DialogService
{
    public interface ICustomDialogService
    {
        Task<bool> ShowErrorDialog(string title, string message, string btnText);
    }
}