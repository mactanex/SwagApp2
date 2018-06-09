using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using SwagApp2.DataStores;
using SwagApp2.Models;
using Xamarin.Forms;

namespace SwagApp2.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        private readonly IListStore _listStore;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IPageDialogService _dialogService;
        private readonly bool _isValid;

        private ToDoList _selectedToDoItem;
        public ToDoList SelectedToDoItem
        {
            get => _selectedToDoItem;
            set => SetProperty(ref _selectedToDoItem, value);
        }

        private ObservableCollection<ToDoList> _listNameCollection;
        public ObservableCollection<ToDoList> ListNameCollection
        {
            get => _listNameCollection;
            set => SetProperty(ref _listNameCollection, value);
        }

        private int _listHeight;
        public int ListHeight
        {
            get => _listHeight;
            set => SetProperty(ref _listHeight, value);
        }

        private int _listRowHeight;
        public int ListRowHeight
        {
            get => _listRowHeight;
            set => SetProperty(ref _listRowHeight, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        
        public ListPageViewModel(INavigationService navigationService,
            IListStore listStore,
            IApplicationUserService applicationUserService,
            IPageDialogService dialogService)
            : base(navigationService)
        {
            _listStore = listStore;
            _applicationUserService = applicationUserService;
            _dialogService = dialogService;

            if (_applicationUserService.DisplayName == null || _applicationUserService.Name == null)
            {
                _isValid = false;
                Message = "Please configure settings";
            }
            else
            {
                _isValid = true;
                Message = $"Here are your lists, {_applicationUserService.Name}";
            }
            
            ListRowHeight = 50;
            SelectedToDoItem = null;
            Title = "List Collection";
        }

        public DelegateCommand NewListCommand => new DelegateCommand(NewListCommandExecuted, () => _isValid);

        private async void NewListCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("NewListPageModal", UriKind.Relative));
        }

        public DelegateCommand EditListCommand => new DelegateCommand(UpdateListCommandExecuted, () => SelectedToDoItem != null && _isValid )
                .ObservesProperty(() => SelectedToDoItem);

        private async void UpdateListCommandExecuted()
        {
            await NavigationService.NavigateAsync(
                new Uri("SingleListPage", UriKind.Relative),
                new NavigationParameters { {"List", _selectedToDoItem} } );
        }

        public DelegateCommand DeleteListCommand => new DelegateCommand(DeleteListCommandExecuted, () => SelectedToDoItem != null && _isValid )
               .ObservesProperty(() => SelectedToDoItem);

        private async void DeleteListCommandExecuted()
        {
            await _listStore.DeleteListAsync(_selectedToDoItem.Name);
            ListNameCollection = new ObservableCollection<ToDoList>(await _listStore.GetAllListsAsync());
            ListHeight = ListNameCollection.Count * ListRowHeight;
            SelectedToDoItem = null;
        }

        #region Navigation

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("NewList"))
            {
                var list = (ToDoList) parameters["NewList"];
                list = await _listStore.CreateListAsync(list);
                if (list == null)
                    await _dialogService.DisplayAlertAsync("Error", "Could not create list!", "Ok");
            }

            ListNameCollection = new ObservableCollection<ToDoList>(await _listStore.GetAllListsAsync());
            ListHeight = ListNameCollection.Count * ListRowHeight;
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        #endregion

    }
}