using Prism.Commands;
using Prism.Navigation;
using SwagApp.Models;
using SwagApp2.DataStores;

namespace SwagApp2.ViewModels
{
    public class NewListPageModalViewModel : ViewModelBase
    {
        private readonly IListStore _listStore;
        public NewListPageModalViewModel(INavigationService navigationService, IListStore listStore) : base(navigationService)
        {
            _listStore = listStore;
            Title = "New list";
        }

        private string _newListName;
        public string NewListName
        {
            get => _newListName;
            set => SetProperty(ref _newListName, value);
        }

        private string _newListNameErrorMessage = string.Empty;

        public string NewListNameErrorMessage
        {
            get => _newListNameErrorMessage;
            set => SetProperty(ref _newListNameErrorMessage, value);
        }

        public string NewListButtonTxt => "Add List";

        public DelegateCommand AddListCommand => new DelegateCommand(OnAddListCommandExecuted, AddListCommandCanExecute).ObservesProperty(() => NewListName);
        private async void OnAddListCommandExecuted()
        {

            if (await _listStore.CreateListAsync(new ToDoList {Name = _newListName}) == null)
            {
                NewListNameErrorMessage = "A list with that name exists!";
            }
            else
            {
                await _navigationService.GoBackAsync(new NavigationParameters { { "NewList", _newListName } });
            }
        }

        private bool AddListCommandCanExecute()
        {
            return (!string.IsNullOrEmpty(_newListName));
        }
    }
}