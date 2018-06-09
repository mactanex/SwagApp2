using System;
using Prism.Commands;
using Prism.Navigation;

namespace SwagApp2.ViewModels
{
    public class MasterDetailPageViewModel : ViewModelBase
    {
        public MasterDetailPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = "MasterDetailPage";
            NavigateCommand = new DelegateCommand<string>(NavigateAsync);
        }

        public string NavigateToListViewTxt => "List Collection";
        public string NavigateToSettingsTxt => "Settings";

        public DelegateCommand<string> NavigateCommand { get; }

        private async void NavigateAsync(string page)
        {
            await NavigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }


    }
}