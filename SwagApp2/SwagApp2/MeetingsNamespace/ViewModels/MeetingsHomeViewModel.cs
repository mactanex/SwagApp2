using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation;
using SwagApp2.DataStores;
using SwagApp2.MeetingsNamespace.Datastores;
using SwagApp2.MeetingsNamespace.Models;
using SwagApp2.MeetingsNamespace.Views;
using SwagApp2.Models;

namespace SwagApp2.ViewModels
{
	public class MeetingsHomeViewModel : ViewModelBase
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMeetingStorage _meetingStorage;
        private readonly bool _isValid;


        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private ObservableCollection<Meeting> _meetingCollection;
        public ObservableCollection<Meeting> MeetingCollection
        {
            get => _meetingCollection;
            set => SetProperty(ref _meetingCollection, value);
        }

        public MeetingsHomeViewModel(INavigationService navigationService, IApplicationUserService applicationUserService, IMeetingStorage meetingStorage):base(navigationService)
        {
            _applicationUserService = applicationUserService;
            _meetingStorage = meetingStorage;
            if (_applicationUserService.DisplayName == null || _applicationUserService.Name == null)
            {
                _isValid = false;
                Message = "Please configure settings";
            }
            else
            {
                _isValid = true;
                Message = $"Here are your appointments, {_applicationUserService.Name}";
            }
        }







	    #region Navigation

	    public override async void OnNavigatingTo(INavigationParameters parameters)
	    {


	        //if (parameters.ContainsKey("NewList"))
	        //{
	        //    var list = (ToDoList)parameters["NewList"];
	        //    list = await _listStore.CreateListAsync(list);
	        //    if (list == null)
	        //        await _dialogService.DisplayAlertAsync("Error", "Could not create list!", "Ok");
	        //}

	        //ListNameCollection = new ObservableCollection<ToDoList>(await _listStore.GetAllListsAsync());
	        MeetingCollection = new ObservableCollection<Meeting>(await _meetingStorage.GetAllListsAsync());
            
	        //ListHeight = ListNameCollection.Count * ListRowHeight;
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
