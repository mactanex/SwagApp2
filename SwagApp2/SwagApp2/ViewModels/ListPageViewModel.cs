using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Navigation;
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

        private ObservableCollection<string> _listNameCollection;
        public ObservableCollection<string> ListNameCollection
        {
            get => _listNameCollection;
            set => SetProperty(ref _listNameCollection, value);
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            ListNameCollection = new ObservableCollection<string>(await _listStore.GetAllLists());
        }

    }
}