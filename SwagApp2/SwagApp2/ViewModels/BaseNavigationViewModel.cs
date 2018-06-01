using Prism.Navigation;

namespace SwagApp2.ViewModels
{
    public class BaseNavigationViewModel : ViewModelBase
    {
        public BaseNavigationViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}