using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using SwagApp2.DialogService;
using SwagApp2.Models;

namespace SwagApp2.ViewModels.CustomDialog
{
    public class CustomErrorDialogViewModel : ViewModelBase
    {
        private CustomDialogService _sender;

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private string _btnText;
        public string BtnText
        {
            get => _btnText;
            set => SetProperty(ref _btnText, value);
        }

        public DelegateCommand OkCommand => new DelegateCommand(() =>
        {
            _sender.PageClosedTaskCompletionSource.SetResult(true);
        });

        public CustomErrorDialogViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            Title = (string)parameters["Title"];
            Message = (string) parameters["Message"];
            BtnText = (string) parameters["BtnText"];
            _sender = (CustomDialogService) parameters["Sender"];            
        }
    }           
}