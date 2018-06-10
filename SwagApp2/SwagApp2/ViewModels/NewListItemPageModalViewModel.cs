using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using SwagApp2.Models;

namespace SwagApp2.ViewModels
{
	public class NewListItemPageModalViewModel : ViewModelBase
	{
	    private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

	    private string _description;

	    public string Description
	    {
	        get => _description;
	        set => SetProperty(ref _description, value);
	    }

	    public NewListItemPageModalViewModel(INavigationService navigationService) : base(navigationService)
	    {
	        Title = "Add a new item";
	    }

        public DelegateCommand AddItemCommand => new DelegateCommand(AddCommandOnExecuted, () => !string.IsNullOrEmpty(Name))
            .ObservesProperty(() => Name);

	    private async void AddCommandOnExecuted()
	    {
	        var listItem = new ListItem();
	        listItem.Name = Name;
	        listItem.Description = Description;
	        await NavigationService.GoBackAsync(new NavigationParameters {{"ListItem", listItem}});
	    }
	}
}
