using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using SwagApp.Models;
using SwagApp2.DataStores;

namespace SwagApp2.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        private readonly IListStore _listStore;

        public ListPageViewModel(INavigationService navigationService, IListStore listStore)
            : base(navigationService)
        {
            _listStore = listStore;
            Title = "List Collection";
        }

        public string AddNewListBrnText => "Add new list";

        private ObservableCollection<string> _listNameCollection;
        public ObservableCollection<string> ListNameCollection
        {
            get => _listNameCollection;
            set => SetProperty(ref _listNameCollection, value);
        }

        public DelegateCommand NewListCommand => new DelegateCommand(NewListCommandExecuted);

        private async void NewListCommandExecuted()
        {
            await _navigationService.NavigateAsync("MasterDetailPageView/NavigationPage/ListPageView/NewListPageModal");
        }

        #region Navigation

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            if (ListNameCollection == null)
            {
                ListNameCollection = new ObservableCollection<string>(await _listStore.GetAllListsAsync());
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (ListNameCollection != null && parameters.ContainsKey("NewList"))
            {
                ListNameCollection.Add(parameters["NewList"] as string);
            }
        }

        #endregion
    }
}