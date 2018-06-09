using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation;
using SwagApp2.Models;

namespace SwagApp2.ViewModels
{
	public class SingleListPageViewModel : ViewModelBase
	{
	    private ToDoList _currentList;

	    public SingleListPageViewModel(INavigationService navigationService) : base(navigationService)
	    {
	    }

        public override void OnNavigatingTo(INavigationParameters parameters)
	    {

	    }

	    public override void OnNavigatedFrom(INavigationParameters parameters)
	    {

	    }

	    public override void OnNavigatedTo(INavigationParameters parameters)
	    {

	    }

	}
}
