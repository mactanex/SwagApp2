using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;

namespace SwagApp2.ViewModels
{
    public class BaseNavigationPageViewModel : ViewModelBase
    {
        public BaseNavigationPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
