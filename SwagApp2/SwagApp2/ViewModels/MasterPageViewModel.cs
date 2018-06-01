using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;

namespace SwagApp2.ViewModels
{
    public class MasterPageViewModel : ViewModelBase
    {
        private string _lastUri = string.Empty;
        public MasterPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = "Swag App V2";
        }

        public string NavigateToListViewTxt => "List Collection";
        public string NavigateToStatisticsTxt => "Statistics";

    }
}
