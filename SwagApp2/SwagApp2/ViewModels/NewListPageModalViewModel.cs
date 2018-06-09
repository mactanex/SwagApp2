using Prism.Commands;
using Prism.Navigation;
using SwagApp2.DataStores;
using SwagApp2.Models;
using SwagApp2.Views;

namespace SwagApp2.ViewModels
{
    public class NewListPageModalViewModel : ViewModelBase
    {
        private readonly IListStore _listStore;
        private readonly IApplicationUserService _applicationUserService;
        public NewListPageModalViewModel(INavigationService navigationService, IListStore listStore, IApplicationUserService applicationUserService)
            : base(navigationService)
        {
            _applicationUserService = applicationUserService;
            _listStore = listStore;
            Title = "New List";
        }

        private string _newListName;
        public string NewListName
        {
            get => _newListName;
            set => SetProperty(ref _newListName, value);
        }

        public string NewListButtonTxt => "Add List";

        public DelegateCommand AddListCommand => 
            new DelegateCommand(OnAddListCommandExecuted, AddListCommandCanExecute)
                .ObservesProperty(() => NewListName);

        private async void OnAddListCommandExecuted()
        {
            var newList = new ToDoList(_newListName)
                { Owner = _applicationUserService.DisplayName };
            await NavigationService.GoBackAsync(new NavigationParameters { { "NewList", newList } });
        }

        private bool AddListCommandCanExecute()
        {
            return (!string.IsNullOrEmpty(_newListName));
        }

        public override async void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }
    }
}