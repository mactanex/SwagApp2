using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SwagApp2.DialogService;
using SwagApp2.Models;

namespace SwagApp2.ViewModels.CustomDialog
{
    public class CustomErrorDialogViewModel : CustomDialogViewModelBase
    {
        public DelegateCommand OkCommand => new DelegateCommand(() =>
        {
            Completion.SetResult(true);
        });

        public CustomErrorDialogViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Title = (string)parameters["Title"];
            Message = (string) parameters["Message"];
            BtnText = (string) parameters["BtnText"];        
        }
    }           
}